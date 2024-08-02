
namespace Generic.FileParsers.Abstractions;

public interface IYmlSerializer
{
    T Deserialize<T>(string yml);
}
