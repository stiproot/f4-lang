
namespace Generic.Cb.Abstractions;

public interface IClusterFactory
{
    Task<ICluster> Connect(
        string baseUrl, 
        string usrname, 
        string pwd
    );
}