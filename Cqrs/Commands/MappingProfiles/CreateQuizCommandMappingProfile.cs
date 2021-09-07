using AspNetCoreVueStarter.Data.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Commands.MappingProfiles
{
    public class CreateQuizCommandMappingProfile : Profile
    {
        public CreateQuizCommandMappingProfile()
        {
            CreateMap<CreateQuizCommand, QuizEntity>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions));

            CreateMap<CreateQuizCommand.Question, QuestionEntity>()
                .ForMember(d => d.QuestionText, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.AnswerOptions, o => o.MapFrom(s => s.AnswerOptions));

            CreateMap<CreateQuizCommand.AnswerOption, AnswerOptionEntity>()
                .ForMember(d => d.AnswerOptionText, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.IsCorrectAnswer, o => o.MapFrom(s => s.IsCorrectAnswer));
        }
    }
}
