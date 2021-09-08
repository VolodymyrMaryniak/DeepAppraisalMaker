using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, UpdateQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<UpdateQuizCommandResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany()
                 .Include(x => x.Questions)
                 .ThenInclude(x => x.AnswerOptions)
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            quizEntity = _mapper.Map<QuizEntity>(request);

            quizEntity.ModifiedDate = DateTime.Now;
            await _quizRepository.UpdateAsync();

            return new UpdateQuizCommandResult { Success = true };
        }
    }
}
