
namespace Generic.Cb.Extensions;

public static class ClusterExtensions
{
    public static ValueTask<IBucket> ToBucketAsync(this ICluster @this,
        string bucketName
    ) 
        => @this.BucketAsync(bucketName);

    public static ValueTask<Couchbase.KeyValue.IScope> ToScopeAsync(this IBucket @this,
        string scopeName
    ) 
        => @this.ScopeAsync(scopeName);

    public static ValueTask<Couchbase.KeyValue.ICouchbaseCollection> ToCollectionAsync(this Couchbase.KeyValue.IScope @this,
        string collectionName
    ) 
        => @this.CollectionAsync(collectionName);
}
