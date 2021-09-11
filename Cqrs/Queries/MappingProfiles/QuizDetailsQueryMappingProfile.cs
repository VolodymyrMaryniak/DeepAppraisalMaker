using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Queries.MappingProfiles
{
    public class QuizDetailsQueryMappingProfile : Profile
    {
        public QuizDetailsQueryMappingProfile()
        {
            CreateMap<QuizEntity, QuizDetailsQueryResult>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.ModifiedAt, o => o.MapFrom(s => s.ModifiedDate))
                .IncludeBase<QuizEntity, Quiz>();
        }
    }
}
