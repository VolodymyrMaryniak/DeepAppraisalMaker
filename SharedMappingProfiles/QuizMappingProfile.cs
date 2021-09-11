using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.SharedMappingProfiles
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Quiz, QuizEntity>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .ReverseMap();

            CreateMap<Quiz.Question, QuestionEntity>()
                .ForMember(d => d.QuestionText, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.AnswerOptions, o => o.MapFrom(s => s.AnswerOptions))
                .ReverseMap();

            CreateMap<Quiz.AnswerOption, AnswerOptionEntity>()
                .ForMember(d => d.AnswerOptionText, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.IsCorrectAnswer, o => o.MapFrom(s => s.IsCorrectAnswer))
                .ReverseMap();
        }
    }
}
