// <auto-generated/>
#pragma warning disable
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System.Collections.Generic;
using ValueTypeTests.StrongTypedId;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertTeam2Operation1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class UpsertTeam2Operation1170066519 : Marten.Internal.Operations.StorageOperation<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly ValueTypeTests.StrongTypedId.Team2 _document;
        private readonly ValueTypeTests.StrongTypedId.Team2Id _id;
        private readonly System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertTeam2Operation1170066519(ValueTypeTests.StrongTypedId.Team2 document, ValueTypeTests.StrongTypedId.Team2Id id, System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }



        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Weasel.Postgresql.IGroupedParameterBuilder parameterBuilder, Weasel.Postgresql.ICommandBuilder builder, ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session)
        {
            builder.Append("select strong_typed4.mt_upsert_team2(");
            var parameter0 = parameterBuilder.AppendParameter(session.Serializer.ToJson(_document));
            parameter0.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            // .Net Class Type
            var parameter1 = parameterBuilder.AppendParameter(_document.GetType().FullName);
            parameter1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;

            if (document.Id != null)
            {
                var parameter2 = parameterBuilder.AppendParameter(document.Id.Value.Value);
                parameter2.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            }

            else
            {
                var parameter2 = parameterBuilder.AppendParameter<object>(System.DBNull.Value);
            }

            setVersionParameter(parameterBuilder);
            builder.Append(')');
        }

    }

    // END: UpsertTeam2Operation1170066519
    
    
    // START: InsertTeam2Operation1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class InsertTeam2Operation1170066519 : Marten.Internal.Operations.StorageOperation<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly ValueTypeTests.StrongTypedId.Team2 _document;
        private readonly ValueTypeTests.StrongTypedId.Team2Id _id;
        private readonly System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertTeam2Operation1170066519(ValueTypeTests.StrongTypedId.Team2 document, ValueTypeTests.StrongTypedId.Team2Id id, System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }



        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Weasel.Postgresql.IGroupedParameterBuilder parameterBuilder, Weasel.Postgresql.ICommandBuilder builder, ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session)
        {
            builder.Append("select strong_typed4.mt_insert_team2(");
            var parameter0 = parameterBuilder.AppendParameter(session.Serializer.ToJson(_document));
            parameter0.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            // .Net Class Type
            var parameter1 = parameterBuilder.AppendParameter(_document.GetType().FullName);
            parameter1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;

            if (document.Id != null)
            {
                var parameter2 = parameterBuilder.AppendParameter(document.Id.Value.Value);
                parameter2.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            }

            else
            {
                var parameter2 = parameterBuilder.AppendParameter<object>(System.DBNull.Value);
            }

            setVersionParameter(parameterBuilder);
            builder.Append(')');
        }

    }

    // END: InsertTeam2Operation1170066519
    
    
    // START: UpdateTeam2Operation1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class UpdateTeam2Operation1170066519 : Marten.Internal.Operations.StorageOperation<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly ValueTypeTests.StrongTypedId.Team2 _document;
        private readonly ValueTypeTests.StrongTypedId.Team2Id _id;
        private readonly System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateTeam2Operation1170066519(ValueTypeTests.StrongTypedId.Team2 document, ValueTypeTests.StrongTypedId.Team2Id id, System.Collections.Generic.Dictionary<ValueTypeTests.StrongTypedId.Team2Id, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }



        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Weasel.Postgresql.IGroupedParameterBuilder parameterBuilder, Weasel.Postgresql.ICommandBuilder builder, ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session)
        {
            builder.Append("select strong_typed4.mt_update_team2(");
            var parameter0 = parameterBuilder.AppendParameter(session.Serializer.ToJson(_document));
            parameter0.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            // .Net Class Type
            var parameter1 = parameterBuilder.AppendParameter(_document.GetType().FullName);
            parameter1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;

            if (document.Id != null)
            {
                var parameter2 = parameterBuilder.AppendParameter(document.Id.Value.Value);
                parameter2.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            }

            else
            {
                var parameter2 = parameterBuilder.AppendParameter<object>(System.DBNull.Value);
            }

            setVersionParameter(parameterBuilder);
            builder.Append(')');
        }

    }

    // END: UpdateTeam2Operation1170066519
    
    
    // START: QueryOnlyTeam2Selector1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class QueryOnlyTeam2Selector1170066519 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ValueTypeTests.StrongTypedId.Team2>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyTeam2Selector1170066519(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ValueTypeTests.StrongTypedId.Team2 Resolve(System.Data.Common.DbDataReader reader)
        {

            ValueTypeTests.StrongTypedId.Team2 document;
            document = _serializer.FromJson<ValueTypeTests.StrongTypedId.Team2>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ValueTypeTests.StrongTypedId.Team2> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ValueTypeTests.StrongTypedId.Team2 document;
            document = await _serializer.FromJsonAsync<ValueTypeTests.StrongTypedId.Team2>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyTeam2Selector1170066519
    
    
    // START: LightweightTeam2Selector1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class LightweightTeam2Selector1170066519 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>, Marten.Linq.Selectors.ISelector<ValueTypeTests.StrongTypedId.Team2>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightTeam2Selector1170066519(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ValueTypeTests.StrongTypedId.Team2 Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(reader.GetFieldValue<string>(0));

            ValueTypeTests.StrongTypedId.Team2 document;
            document = _serializer.FromJson<ValueTypeTests.StrongTypedId.Team2>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ValueTypeTests.StrongTypedId.Team2> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(await reader.GetFieldValueAsync<string>(0, token));

            ValueTypeTests.StrongTypedId.Team2 document;
            document = await _serializer.FromJsonAsync<ValueTypeTests.StrongTypedId.Team2>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightTeam2Selector1170066519
    
    
    // START: IdentityMapTeam2Selector1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class IdentityMapTeam2Selector1170066519 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>, Marten.Linq.Selectors.ISelector<ValueTypeTests.StrongTypedId.Team2>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapTeam2Selector1170066519(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ValueTypeTests.StrongTypedId.Team2 Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(reader.GetFieldValue<string>(0));
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ValueTypeTests.StrongTypedId.Team2 document;
            document = _serializer.FromJson<ValueTypeTests.StrongTypedId.Team2>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ValueTypeTests.StrongTypedId.Team2> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(await reader.GetFieldValueAsync<string>(0, token));
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ValueTypeTests.StrongTypedId.Team2 document;
            document = await _serializer.FromJsonAsync<ValueTypeTests.StrongTypedId.Team2>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapTeam2Selector1170066519
    
    
    // START: DirtyTrackingTeam2Selector1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class DirtyTrackingTeam2Selector1170066519 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>, Marten.Linq.Selectors.ISelector<ValueTypeTests.StrongTypedId.Team2>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingTeam2Selector1170066519(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ValueTypeTests.StrongTypedId.Team2 Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(reader.GetFieldValue<string>(0));
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ValueTypeTests.StrongTypedId.Team2 document;
            document = _serializer.FromJson<ValueTypeTests.StrongTypedId.Team2>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ValueTypeTests.StrongTypedId.Team2> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = new ValueTypeTests.StrongTypedId.Team2Id(await reader.GetFieldValueAsync<string>(0, token));
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ValueTypeTests.StrongTypedId.Team2 document;
            document = await _serializer.FromJsonAsync<ValueTypeTests.StrongTypedId.Team2>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingTeam2Selector1170066519
    
    
    // START: QueryOnlyTeam2DocumentStorage1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class QueryOnlyTeam2DocumentStorage1170066519 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyTeam2DocumentStorage1170066519(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override ValueTypeTests.StrongTypedId.Team2Id AssignIdentity(ValueTypeTests.StrongTypedId.Team2 document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id.Value;
            return document.Id.Value;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override ValueTypeTests.StrongTypedId.Team2Id Identity(ValueTypeTests.StrongTypedId.Team2 document)
        {
            return document.Id.Value;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyTeam2Selector1170066519(session, _document);
        }


        public override object RawIdentityValue(ValueTypeTests.StrongTypedId.Team2Id id)
        {
            return id.Value;
        }


        public override Npgsql.NpgsqlParameter BuildManyIdParameter(ValueTypeTests.StrongTypedId.Team2Id[] ids)
        {
            return new(){Value = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(ids, x => x.Value)), NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text};
        }

    }

    // END: QueryOnlyTeam2DocumentStorage1170066519
    
    
    // START: LightweightTeam2DocumentStorage1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class LightweightTeam2DocumentStorage1170066519 : Marten.Internal.Storage.LightweightDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightTeam2DocumentStorage1170066519(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override ValueTypeTests.StrongTypedId.Team2Id AssignIdentity(ValueTypeTests.StrongTypedId.Team2 document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id.Value;
            return document.Id.Value;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override ValueTypeTests.StrongTypedId.Team2Id Identity(ValueTypeTests.StrongTypedId.Team2 document)
        {
            return document.Id.Value;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightTeam2Selector1170066519(session, _document);
        }


        public override object RawIdentityValue(ValueTypeTests.StrongTypedId.Team2Id id)
        {
            return id.Value;
        }


        public override Npgsql.NpgsqlParameter BuildManyIdParameter(ValueTypeTests.StrongTypedId.Team2Id[] ids)
        {
            return new(){Value = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(ids, x => x.Value)), NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text};
        }

    }

    // END: LightweightTeam2DocumentStorage1170066519
    
    
    // START: IdentityMapTeam2DocumentStorage1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class IdentityMapTeam2DocumentStorage1170066519 : Marten.Internal.Storage.IdentityMapDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapTeam2DocumentStorage1170066519(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override ValueTypeTests.StrongTypedId.Team2Id AssignIdentity(ValueTypeTests.StrongTypedId.Team2 document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id.Value;
            return document.Id.Value;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override ValueTypeTests.StrongTypedId.Team2Id Identity(ValueTypeTests.StrongTypedId.Team2 document)
        {
            return document.Id.Value;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapTeam2Selector1170066519(session, _document);
        }


        public override object RawIdentityValue(ValueTypeTests.StrongTypedId.Team2Id id)
        {
            return id.Value;
        }


        public override Npgsql.NpgsqlParameter BuildManyIdParameter(ValueTypeTests.StrongTypedId.Team2Id[] ids)
        {
            return new(){Value = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(ids, x => x.Value)), NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text};
        }

    }

    // END: IdentityMapTeam2DocumentStorage1170066519
    
    
    // START: DirtyTrackingTeam2DocumentStorage1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class DirtyTrackingTeam2DocumentStorage1170066519 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingTeam2DocumentStorage1170066519(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override ValueTypeTests.StrongTypedId.Team2Id AssignIdentity(ValueTypeTests.StrongTypedId.Team2 document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            return document.Id.Value;
            return document.Id.Value;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertTeam2Operation1170066519
            (
                document, Identity(document),
                session.Versions.ForType<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ValueTypeTests.StrongTypedId.Team2 document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override ValueTypeTests.StrongTypedId.Team2Id Identity(ValueTypeTests.StrongTypedId.Team2 document)
        {
            return document.Id.Value;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingTeam2Selector1170066519(session, _document);
        }


        public override object RawIdentityValue(ValueTypeTests.StrongTypedId.Team2Id id)
        {
            return id.Value;
        }


        public override Npgsql.NpgsqlParameter BuildManyIdParameter(ValueTypeTests.StrongTypedId.Team2Id[] ids)
        {
            return new(){Value = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(ids, x => x.Value)), NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text};
        }

    }

    // END: DirtyTrackingTeam2DocumentStorage1170066519
    
    
    // START: Team2BulkLoader1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class Team2BulkLoader1170066519 : Marten.Internal.CodeGeneration.BulkLoader<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id> _storage;

        public Team2BulkLoader1170066519(Marten.Internal.Storage.IDocumentStorage<ValueTypeTests.StrongTypedId.Team2, ValueTypeTests.StrongTypedId.Team2Id> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY strong_typed4.mt_doc_team2(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_team2_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into strong_typed4.mt_doc_team2 (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_team2_temp.\"id\", mt_doc_team2_temp.\"data\", mt_doc_team2_temp.\"mt_version\", mt_doc_team2_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_team2_temp left join strong_typed4.mt_doc_team2 on mt_doc_team2_temp.id = strong_typed4.mt_doc_team2.id where strong_typed4.mt_doc_team2.id is null)";

        public const string OVERWRITE_SQL = "update strong_typed4.mt_doc_team2 target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_team2_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_team2_temp (like strong_typed4.mt_doc_team2 including defaults)";


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ValueTypeTests.StrongTypedId.Team2 document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id.Value.Value, NpgsqlTypes.NpgsqlDbType.Text, cancellation);
            await writer.WriteAsync(JasperFx.Core.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }

    }

    // END: Team2BulkLoader1170066519
    
    
    // START: Team2Provider1170066519
    [global::System.CodeDom.Compiler.GeneratedCode("JasperFx", "1.0.0")]
    public sealed class Team2Provider1170066519 : Marten.Internal.Storage.DocumentProvider<ValueTypeTests.StrongTypedId.Team2>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public Team2Provider1170066519(Marten.Schema.DocumentMapping mapping) : base(new Team2BulkLoader1170066519(new QueryOnlyTeam2DocumentStorage1170066519(mapping)), new QueryOnlyTeam2DocumentStorage1170066519(mapping), new LightweightTeam2DocumentStorage1170066519(mapping), new IdentityMapTeam2DocumentStorage1170066519(mapping), new DirtyTrackingTeam2DocumentStorage1170066519(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: Team2Provider1170066519
    
    
}

