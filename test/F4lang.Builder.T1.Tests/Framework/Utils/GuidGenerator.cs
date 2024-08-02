
namespace F4lang.Builder.T1.Tests.Framework.Utils;

[ExcludeFromCodeCoverage]
public static class GuidGenerator
{
	public static string NewGuidAsString() => Guid.NewGuid().ToString();
}
