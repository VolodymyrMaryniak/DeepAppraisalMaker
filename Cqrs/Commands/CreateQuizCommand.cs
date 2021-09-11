using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Models;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Commands
{
    public class CreateQuizCommand : Quiz, IRequest<CreateQuizCommandResult>
    {
    }
}
