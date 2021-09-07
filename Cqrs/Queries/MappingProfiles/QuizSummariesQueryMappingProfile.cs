using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Queries.MappingProfiles
{
    public class QuizSummariesQueryMappingProfile : Profile
    {
        public QuizSummariesQueryMappingProfile()
        {
            CreateMap<QuizEntity, QuizSummariesQueryResult.QuizSummary>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.ModifiedAt, o => o.MapFrom(s => s.ModifiedDate));
        }
    }
}
