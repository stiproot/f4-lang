
namespace Generic.FileParsers.Abstractions;

public interface IJsnSerializer
{
    T Deserialize<T>(string jsn);
}
