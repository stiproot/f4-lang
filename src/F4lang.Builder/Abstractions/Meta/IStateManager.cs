namespace F4lang.Builder.Abstractions;

public interface IStateManager :
	IRootBranch,
	IIfBranch,
	IHashBranch,
	IBranchBranch,
	IPathBranch,
	IAgntBranch
{
	IMetaNode? RootNode { get; set; }
	IMetaNode? StateNode { get; set; }
	INode Build();
}