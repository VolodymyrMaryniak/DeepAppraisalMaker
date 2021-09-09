using AspNetCoreVueStarter.Cqrs.Commands.Results;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Commands
{
    public class DeleteQuizCommand : IRequest<DeleteQuizCommandResult>
    {
        public int Id { get; set; }
    }
}
