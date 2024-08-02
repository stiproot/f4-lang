
namespace F4lang.Store.Api.Abstractions;

public interface IMapper<in TSrc, out TTrgt>
    where TTrgt : new()
{
    TTrgt Map(TSrc source);
}
