using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Models;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Commands
{
    public class UpdateQuizCommand : Quiz, IRequest<UpdateQuizCommandResult>
    {
        public int Id { get; set; }
    }
}
