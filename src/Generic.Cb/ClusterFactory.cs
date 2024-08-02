
namespace Generic.Cb;

public class ClusterFactory : IClusterFactory
{
    public async Task<ICluster> Connect(
        string baseUrl, 
        string usrname, 
        string pwd
    )
    {
        return await Cluster.ConnectAsync(
            baseUrl,
            usrname,
            pwd
        );
    }
}