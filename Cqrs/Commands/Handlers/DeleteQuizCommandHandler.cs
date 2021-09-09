using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, DeleteQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<DeleteQuizCommandResult> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (quizEntity == null)
                throw new NotFoundException();

            await _quizRepository.DeleteAsync(quizEntity);

            return new DeleteQuizCommandResult { Success = true };
        }
    }
}
