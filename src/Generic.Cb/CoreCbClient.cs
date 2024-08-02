using Generic.Cb.Extensions;
using Couchbase.KeyValue;
using Microsoft.Extensions.Options;

namespace Generic.Cb;

public class CoreCbClient : ICoreCbClient
{
    private readonly IOptions<CouchbaseOptions> _options;
    private readonly ICbClusterInit _clusterInit;
    private ICluster? _cluster;
    private IBucket? _bucket;

    public CoreCbClient(
        IOptions<CouchbaseOptions> options,
        ICbClusterInit clusterInit
    )
    {
        this._options = options ?? throw new ArgumentNullException(nameof(options));
        this._clusterInit = clusterInit ?? throw new ArgumentNullException(nameof(clusterInit));
    }

    public async Task<IEnumerable<TRes>> QueryScopeAsync<TRes>(
        string scopeName,
        string query
    )
    {
        if (this._cluster is null) this._cluster = await this._clusterInit.InitAsync();
        if (this._bucket is null) this._bucket = await this._cluster.ToBucketAsync(this._options.Value.DefaultBucket);

        IScope scope = await this._bucket.ScopeAsync(scopeName);
        var qryRes = await scope.QueryAsync<TRes>(query);

        List<TRes> res = new();
        await foreach (var row in qryRes) res.Add(row);
        return res;
    }

    public async Task UpsertDocumentAsync(
        string scopeName,
        string collectionName,
        string documentId,
        object document
    )
    {
        if (this._cluster is null) this._cluster = await this._clusterInit.InitAsync();
        if (this._bucket is null) this._bucket = await this._cluster.ToBucketAsync(this._options.Value.DefaultBucket);

        var scope = await this._bucket.ToScopeAsync(scopeName);
        var collection = await scope.ToCollectionAsync(collectionName);
        await collection.UpsertAsync(documentId, document);
    }
}