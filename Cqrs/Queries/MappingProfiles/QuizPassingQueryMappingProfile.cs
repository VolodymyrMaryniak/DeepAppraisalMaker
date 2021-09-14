using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Queries.MappingProfiles
{
    public class QuizPassingQueryMappingProfile : Profile
    {
        public QuizPassingQueryMappingProfile()
        {
            CreateMap<QuizEntity, QuizPassingQueryResult>()
               .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
               .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
               .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions));

            CreateMap<QuestionEntity, QuizPassingQueryResult.Question>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.QuestionText))
                .ForMember(d => d.AnswerOptions, o => o.MapFrom(s => s.AnswerOptions));

            CreateMap<AnswerOptionEntity, QuizPassingQueryResult.AnswerOption>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.AnswerOptionText));
        }
    }
}
