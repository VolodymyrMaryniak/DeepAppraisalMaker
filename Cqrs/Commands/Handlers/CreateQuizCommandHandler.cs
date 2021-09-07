using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreateQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public CreateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<CreateQuizCommandResult> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = _mapper.Map<QuizEntity>(request);

            var now = DateTime.Now;

            quizEntity.CreatedDate = now;
            quizEntity.ModifiedDate = now;

            await _quizRepository.AddAsync(quizEntity);

            return new CreateQuizCommandResult {Success = true};
        }
    }
}
