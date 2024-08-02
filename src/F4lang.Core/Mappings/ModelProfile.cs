using AutoMapper;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003, SKEXP0001

namespace F4lang.Core.Mappings;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<FunctionResult, AgntQryRes>()
            .ForMember(dest => dest.RawTxtRes, opt => opt.MapFrom(src => src.ToString()));

        CreateMap<IAgntQry, AgntMemoryQry>();
            // .ForMember(dest => dest.Qry, opt => opt.MapFrom(src => src.Qry));

        CreateMap<MemoryQueryResult, AgntMemoryQryRes>()
            .ForMember(dest => dest.Txt, opt => opt.MapFrom(src => src.Metadata.Text));
    }
}
