
using System.Collections.Concurrent;
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Builder.Core;

public static class Hashes
{
    private static Dictionary<Type, string> _hash =	new()
    {
        { typeof(ICoderAgntActor), AgntIds.CODER },
        { typeof(ICodeValidatorAgntActor), AgntIds.CODE_VALIDATOR },
    };

    public static readonly ConcurrentDictionary<Type, string> ActorTypeIdHash = new ConcurrentDictionary<Type, string>(_hash);
}