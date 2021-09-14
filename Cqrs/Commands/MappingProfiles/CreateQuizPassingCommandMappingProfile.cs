using AspNetCoreVueStarter.Data.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Commands.MappingProfiles
{
    public class CreateQuizPassingCommandMappingProfile : Profile
    {
        public CreateQuizPassingCommandMappingProfile()
        {
            CreateMap<CreateQuizPassingCommand, QuizPassingEntity>()
                .ForMember(d => d.QuizId, o => o.MapFrom(s => s.QuizId))
                .ForMember(d => d.StudentId, o => o.MapFrom(s => s.StudentId))
                .ForMember(d => d.StudentAnswers, o => o.MapFrom(s => s.StudentAnswers));

            CreateMap<CreateQuizPassingCommand.StudentAnswer, StudentAnswerEntity>()
                .ForMember(d => d.QuestionId, o => o.MapFrom(s => s.QuestionId))
                .ForMember(d => d.ChosenAnswerId, o => o.MapFrom(s => s.AnswerOptionId));
        }
    }
}
