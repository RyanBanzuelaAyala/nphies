using AutoMapper;
using QApi.V3.Model.Eligibility;
using QDomain.Model.Eligibility;

namespace QApi.V3.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NAPHIES_Eligibility_ParamVM, NAPHIES_Eligibility_Param>();
        }
    }
}
