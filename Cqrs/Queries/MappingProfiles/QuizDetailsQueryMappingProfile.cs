using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Queries.MappingProfiles
{
    public class QuizDetailsQueryMappingProfile : Profile
    {
        public QuizDetailsQueryMappingProfile()
        {
            CreateMap<QuizEntity, QuizDetailsQueryResult>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.ModifiedAt, o => o.MapFrom(s => s.ModifiedDate));

            CreateMap<QuestionEntity, QuizDetailsQueryResult.Question>()
                .ForMember(d => d.Text, o => o.MapFrom(s => s.QuestionText))
                .ForMember(d => d.AnswerOptions, o => o.MapFrom(s => s.AnswerOptions));

            CreateMap<AnswerOptionEntity, QuizDetailsQueryResult.AnswerOption>()
                .ForMember(d => d.Text, o => o.MapFrom(s => s.AnswerOptionText))
                .ForMember(d => d.IsCorrectAnswer, o => o.MapFrom(s => s.IsCorrectAnswer));
        }
    }
}
