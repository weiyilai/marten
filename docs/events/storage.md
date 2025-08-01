# Event Store Schema Objects

## Overriding the Schema

By default, the event store database objects are created in the default schema for the active `IDocumentStore`. If you wish,
you can segregate the event store objects into a separate schema with this syntax:

<!-- snippet: sample_setting_event_schema -->
<a id='snippet-sample_setting_event_schema'></a>
```cs
var store = DocumentStore.For(_ =>
{
    _.Connection("some connection string");

    // Places all the Event Store schema objects
    // into the "events" schema
    _.Events.DatabaseSchemaName = "events";
});
```
<sup><a href='https://github.com/JasperFx/marten/blob/master/src/Marten.Testing/Examples/ConfiguringDocumentStore.cs#L200-L209' title='Snippet source file'>snippet source</a> | <a href='#snippet-sample_setting_event_schema' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## Database Tables

The events are stored in the `mt_events` table, with these columns:

* `seq_id` - A sequential identifier that acts as the primary key
* `id` - A Guid value uniquely identifying the event across databases
* `stream_id` - A foreign key to the event stream that contains the event
* `version` - A numerical version of the event's position within its event stream
* `data` - The actual event data stored as JSONB
* `type` - A string identifier for the event type that's derived from the event type name. For example, events of type `IssueResolved` would be identified as "issue_resolved." The `type`
  column exists so that Marten can be effectively used without the underlying JSON serializer having to embed type metadata.
* `timestamp` - A database timestamp written by the database when events are committed.
* `tenant_id` - Identifies the tenancy of the event
* `mt_dotnet_type` - The full name of the underlying event type, including assembly name, e.g. "Marten.Testing.Events.IssueResolved, Marten.Testing"

The "Async Daemon" projection supports keys off of the sequential id, but we retained the Guid id field for backward compatibility and to retain a potential way to uniquely identify events across databases.

In addition, there are a couple other metadata tables you'll see in your schema:

* `mt_streams` - Metadata about each event stream
* `mt_event_progression` - A durable record about the progress of each async projection through the event store

A function that Marten uses internally:

* `mt_mark_event_progression` - Updates the `mt_event_progression` table

And lastly, there's a document type called `DeadLetterEvent` that Marten adds automatically to record information about
"dead letter events" that are repeatedly erroring in the async daemon and are being skipped in accordance with
the error handling policies in your application's Marten configuration.

## Event Metadata in Code

Hopefully, it's relatively clear how the fields in `mt_events` map to the `IEvent` interface in Marten:

```cs
/// <summary>
///     A reference to the stream that contains
///     this event
/// </summary>
public Guid StreamId { get; set; }

/// <summary>
///     A reference to the stream if the stream
///     identifier mode is AsString
/// </summary>
public string? StreamKey { get; set; }

/// <summary>
///     An alternative Guid identifier to identify
///     events across databases
/// </summary>
public Guid Id { get; set; }

/// <summary>
///     An event's version position within its event stream
/// </summary>
public long Version { get; set; }

/// <summary>
///     A global sequential number identifying the Event
/// </summary>
public long Sequence { get; set; }

/// <summary>
///     The UTC time that this event was originally captured
/// </summary>
public DateTimeOffset Timestamp { get; set; }

public string TenantId { get; set; } = Tenancy.DefaultTenantId;

/// <summary>
///     Optional metadata describing the causation id
/// </summary>
public string? CausationId { get; set; }

/// <summary>
///     Optional metadata describing the correlation id
/// </summary>
public string? CorrelationId { get; set; }

/// <summary>
///     This is meant to be lazy created, and can be null
/// </summary>
public Dictionary<string, object>? Headers { get; set; }
```

The full event data is available on `EventStream` and `IEvent` objects immediately after committing a transaction that involves event capture. See [diagnostics and instrumentation](/diagnostics) for more information on capturing event data in the instrumentation hooks.

## Event Type Names <Badge type="tip" text="8.4" />

If you look into the `mt_events` table in your system you'll see a column named `type` that will
have an alias for the .NET type name that Marten keys off when reading events from the database 
to "know" what .NET type to deserialize the JSON data to. 

The original idea was that people should be able to easily move event types around in their
solution without breaking the storage as full type names changed, so we purposely used _only_ the
type name of the .NET type for the event alias. In real life usage though, sometimes people will
use completely different .NET types with the same type name like in this example:

```csharp
public class GroupEvents
{
    public record Created(string Name);
}

public class UserEvents
{
    public record Created(string Name);
}
```

In that case, the original naming scheme of "created" will not correctly disambiguate between the
two different `Created` types above. While you _could_ manually alias all of these event types
yourself to disambiguate, it's too easy to forget to do that. Instead, you can just switch to different
naming schemes like this:

<!-- snippet: sample_event_naming_style -->
<a id='snippet-sample_event_naming_style'></a>
```cs
var builder = Host.CreateApplicationBuilder();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("marten"));

    // This is the default behavior, but just showing you that
    // this is an option
    opts.Events.EventNamingStyle = EventNamingStyle.ClassicTypeName;

    // This mode is "the classic style Marten has always used, except smart enough
    // to disambiguate inner classes that have the same type name"
    opts.Events.EventNamingStyle = EventNamingStyle.SmarterTypeName;

    // Forget all the pretty naming aliases, just use the .NET full type name for
    // the event type name
    opts.Events.EventNamingStyle = EventNamingStyle.FullTypeName;
});
```
<sup><a href='https://github.com/JasperFx/marten/blob/master/src/EventSourcingTests/Examples/NamingStyles.cs#L13-L34' title='Snippet source file'>snippet source</a> | <a href='#snippet-sample_event_naming_style' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Note that you will have to switch out of the "classic" naming mode to disambiguate between event types
with the same class name in different namespaces.

## Optional Indexes

As of Marten 7.0, Marten is omitting indexes that aren't universally necessary, but
you have the option to add some extra, pre-canned indexes. Right now the only option
is to add a unique index back on the `id` column that would be useful for references to
external systems like so:

<!-- snippet: sample_using_optional_event_store_indexes -->
<a id='snippet-sample_using_optional_event_store_indexes'></a>
```cs
var builder = Host.CreateApplicationBuilder();
builder.Services.AddMarten(opts =>
{
    opts.Connection("some connection string");

    // Add the unique index to the id field
    opts.Events.EnableUniqueIndexOnEventId = true;
});
```
<sup><a href='https://github.com/JasperFx/marten/blob/master/src/EventSourcingTests/opting_into_index_on_event_id.cs#L20-L31' title='Snippet source file'>snippet source</a> | <a href='#snippet-sample_using_optional_event_store_indexes' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
