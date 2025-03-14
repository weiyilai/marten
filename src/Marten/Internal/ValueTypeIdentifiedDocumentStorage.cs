using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JasperFx.Core.Reflection;
using Marten.Internal.Operations;
using Marten.Internal.Storage;
using Marten.Linq;
using Marten.Linq.Members;
using Marten.Linq.QueryHandlers;
using Marten.Linq.Selectors;
using Marten.Linq.SqlGeneration;
using Marten.Services;
using Marten.Storage;
using Npgsql;
using Weasel.Core;
using Weasel.Postgresql;
using Weasel.Postgresql.SqlGeneration;

namespace Marten.Internal;

internal class ValueTypeIdentifiedDocumentStorage<TDoc, TSimple, TValueType>: IDocumentStorage<TDoc, TSimple>
{
    private readonly IDocumentStorage<TDoc, TValueType> _inner;
    private readonly Func<TSimple, TValueType> _converter;
    private readonly Func<TValueType,TSimple> _unwrapper;

    public ValueTypeIdentifiedDocumentStorage(ValueTypeInfo valueTypeInfo, IDocumentStorage<TDoc, TValueType> inner)
    {
        _inner = inner;

        _converter = valueTypeInfo.CreateWrapper<TValueType, TSimple>();
        _unwrapper = valueTypeInfo.UnWrapper<TValueType, TSimple>();
    }

    public void Apply(ICommandBuilder builder) => _inner.Apply(builder);

    public string FromObject => _inner.FromObject;
    public Type SelectedType => _inner.SelectedType;
    public string[] SelectFields() => _inner.SelectFields();

    public ISelector BuildSelector(IMartenSession session) => _inner.BuildSelector(session);

    public IQueryHandler<T> BuildHandler<T>(IMartenSession session, ISqlFragment topStatement,
        ISqlFragment currentStatement)
        => _inner.BuildHandler<T>(session, topStatement, currentStatement);

    public ISelectClause UseStatistics(QueryStatistics statistics)
        => _inner.UseStatistics(statistics);

    public Type SourceType => _inner.SourceType;
    public Type IdType => _inner.IdType;
    public bool UseOptimisticConcurrency => _inner.UseOptimisticConcurrency;
    public IOperationFragment DeleteFragment => _inner.DeleteFragment;
    public IOperationFragment HardDeleteFragment => _inner.HardDeleteFragment;
    public IReadOnlyList<DuplicatedField> DuplicatedFields => _inner.DuplicatedFields;
    public DbObjectName TableName => _inner.TableName;
    public Type DocumentType => _inner.DocumentType;
    public TenancyStyle TenancyStyle => _inner.TenancyStyle;

    public Task TruncateDocumentStorageAsync(IMartenDatabase database, CancellationToken ct = default)
        => _inner.TruncateDocumentStorageAsync(database, ct);

    public ISqlFragment FilterDocuments(ISqlFragment query, IMartenSession session)
        => _inner.FilterDocuments(query, session);

    public ISqlFragment DefaultWhereFragment()
        => _inner.DefaultWhereFragment();

    public IQueryableMemberCollection QueryMembers => _inner.QueryMembers;
    public ISelectClause SelectClauseWithDuplicatedFields => _inner.SelectClauseWithDuplicatedFields;
    public bool UseNumericRevisions => _inner.UseNumericRevisions;
    public object RawIdentityValue(object id) => _inner.RawIdentityValue(id);

    public object IdentityFor(TDoc document) => _inner.IdentityFor(document);

    public Guid? VersionFor(TDoc document, IMartenSession session) => _inner.VersionFor(document, session);

    public void Store(IMartenSession session, TDoc document) => _inner.Store(session, document);

    public void Store(IMartenSession session, TDoc document, Guid? version) => _inner.Store(session, document, version);

    public void Store(IMartenSession session, TDoc document, int revision) => _inner.Store(session, document, revision);

    public void Eject(IMartenSession session, TDoc document) => _inner.Eject(session, document);

    public IStorageOperation Update(TDoc document, IMartenSession session, string tenantId) =>
        _inner.Update(document, session, tenantId);

    public IStorageOperation Insert(TDoc document, IMartenSession session, string tenantId)
        => _inner.Insert(document, session, tenantId);

    public IStorageOperation Upsert(TDoc document, IMartenSession session, string tenantId)
        => _inner.Upsert(document, session, tenantId);

    public IStorageOperation Overwrite(TDoc document, IMartenSession session, string tenantId)
        => _inner.Overwrite(document, session, tenantId);

    public IDeletion DeleteForDocument(TDoc document, string tenantId)
        => _inner.DeleteForDocument(document, tenantId);

    public void EjectById(IMartenSession session, object id)
        => _inner.EjectById(session, id);

    public void RemoveDirtyTracker(IMartenSession session, object id)
        => _inner.RemoveDirtyTracker(session, id);

    public IDeletion HardDeleteForDocument(TDoc document, string tenantId)
        => _inner.HardDeleteForDocument(document, tenantId);

    public void SetIdentityFromString(TDoc document, string identityString)
        => _inner.SetIdentityFromString(document, identityString);

    public void SetIdentityFromGuid(TDoc document, Guid identityGuid)
        => _inner.SetIdentityFromGuid(document, identityGuid);

    public void SetIdentity(TDoc document, TSimple identity)
        => _inner.SetIdentity(document, _converter(identity));

    public IDeletion DeleteForId(TSimple id, string tenantId)
        => _inner.DeleteForId(_converter(id), tenantId);

    public Task<TDoc> LoadAsync(TSimple id, IMartenSession session, CancellationToken token)
        => _inner.LoadAsync(_converter(id), session, token);

    public Task<IReadOnlyList<TDoc>> LoadManyAsync(TSimple[] ids, IMartenSession session, CancellationToken token)
        => _inner.LoadManyAsync(ids.Select(_converter).ToArray(), session, token);

    public TSimple AssignIdentity(TDoc document, string tenantId, IMartenDatabase database)
        => _unwrapper(_inner.AssignIdentity(document, tenantId, database));

    public TSimple Identity(TDoc document) => _unwrapper(_inner.Identity(document));

    public ISqlFragment ByIdFilter(TSimple id) => _inner.ByIdFilter(_converter(id));

    public IDeletion HardDeleteForId(TSimple id, string tenantId)
        => _inner.HardDeleteForId(_converter(id), tenantId);

    public NpgsqlCommand BuildLoadCommand(TSimple id, string tenantId)
        => _inner.BuildLoadCommand(_converter(id), tenantId);

    public NpgsqlCommand BuildLoadManyCommand(TSimple[] ids, string tenantId)
        => _inner.BuildLoadManyCommand(ids.Select(_converter).ToArray(), tenantId);

    public object RawIdentityValue(TSimple id) => id;
}