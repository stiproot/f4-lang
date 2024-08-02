namespace F4lang.Builder.Core;

public partial class NodeConfiguration : INodeConfiguration
{
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public bool IgnoresPromisedResults { get; set; }
	public bool RequiresResult { get; set; }
	public string? NextParamName { get; set; }
	public string? Key { get; set; }
	public IWorkflowContext? WorkflowContext { get; set; }
	public List<IMsg> Args { get; init; } = [];
	public List<INode> PromisedArgs { get; init; } = [];
	public List<IMetaNode> MetaPromisedArgs { get; init; } = [];
	public List<Func<IWorkflowContext, IMsg>> ContextArgs { get; init; } = [];
	public ControllerTypes ControllerType { get; set; } = ControllerTypes.None;
	public Action<object>? PreProcess { get; set; }
}