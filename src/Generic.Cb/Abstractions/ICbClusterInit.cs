
namespace Generic.Cb.Abstractions;

public interface ICbClusterInit
{
    Task<ICluster> InitAsync();
}
