using AutoMapper;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003

namespace Slow.Core.Mappings;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<FunctionResult, AgentQryRes>()
            .ForMember(dest => dest.Res, opt => opt.MapFrom(src => src.ToString()));

        CreateMap<IAgentQry, AgentMemoryQry>();
            // .ForMember(dest => dest.Qry, opt => opt.MapFrom(src => src.Qry));

        CreateMap<MemoryQueryResult, AgentMemoryQryRes>()
            .ForMember(dest => dest.Txt, opt => opt.MapFrom(src => src.Metadata.Text));
    }
}
