
using Microsoft.Extensions.Options;

namespace Generic.Cb;

public class CbClusterInit : ICbClusterInit
{
    private readonly CouchbaseOptions _options;    
    private readonly IClusterFactory _clusterFactory;

    public CbClusterInit(
        IOptions<CouchbaseOptions> options,
        IClusterFactory clusterFactory
    )
    {
        this._options = options.Value ?? throw new ArgumentNullException(nameof(options));
        this._clusterFactory = clusterFactory ?? throw new ArgumentNullException(nameof(clusterFactory));
    }

    public async Task<ICluster> InitAsync()
    {
        return await this._clusterFactory.Connect(this._options.BaseUrl, this._options.Usrname, this._options.Pwd);
    } 
}
