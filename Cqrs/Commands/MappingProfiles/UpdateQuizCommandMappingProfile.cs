using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Models;
using AutoMapper;

namespace AspNetCoreVueStarter.Cqrs.Commands.MappingProfiles
{
    public class UpdateQuizCommandMappingProfile : Profile
    {
        public UpdateQuizCommandMappingProfile()
        {
            CreateMap<UpdateQuizCommand, QuizEntity>()
                .IncludeBase<Quiz, QuizEntity>();
        }
    }
}
