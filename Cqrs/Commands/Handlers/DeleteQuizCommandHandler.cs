using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Exceptions;
using AspNetCoreVueStarter.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, DeleteQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly QuizService _quizService;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository, QuizService quizService)
        {
            _quizRepository = quizRepository;
            _quizService = quizService;
        }

        public async Task<DeleteQuizCommandResult> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizService.GetById(request.Id, cancellationToken);

            if (quizEntity == null)
                throw new NotFoundException();

            if (!await _quizService.QuizUsed(request.Id, cancellationToken))
            {
                await _quizRepository.DeleteAsync(quizEntity);
                return new DeleteQuizCommandResult { Success = true };
            }

            quizEntity.IsActive = false;
            await _quizRepository.UpdateAsync();

            return new DeleteQuizCommandResult { Success = true };
        }
    }
}
