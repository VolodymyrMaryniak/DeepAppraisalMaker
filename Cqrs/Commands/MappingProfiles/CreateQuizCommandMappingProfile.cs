using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Commands.MappingProfiles
{
    public class CreateQuizCommandMappingProfile : Profile
    {
        public CreateQuizCommandMappingProfile()
        {
            CreateMap<CreateQuizCommand, QuizEntity>()
                .IncludeBase<Quiz, QuizEntity>();
        }
    }
}
