using Microsoft.Extensions.Logging;

namespace F4lang.Builder.Abstractions;

public interface INodeBuilderFactory
{
	INodeBuilder Create(ILogger? logger = null);
}
