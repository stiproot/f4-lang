namespace F4lang.Builder.Abstractions;

public interface IMetaNodeEdge
{
    IMetaNode? True { get; set; }
    IMetaNode? False { get; set; }
    IMetaNode? Next { get; set; }
    List<IMetaNode?>? Nexts { get; set; }
}