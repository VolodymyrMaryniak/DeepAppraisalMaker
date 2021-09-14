using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data;
using AspNetCoreVueStarter.Data.Models;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class CreateQuizPassingCommandHandler : IRequestHandler<CreateQuizPassingCommand, CreateQuizPassingCommandResult>
    {
        private readonly DamDbContext _quizPassingContext;
        private readonly IMapper _mapper;

        public CreateQuizPassingCommandHandler(DamDbContext quizPassingContext, IMapper mapper)
        {
            _quizPassingContext = quizPassingContext;
            _mapper = mapper;
        }

        public async Task<CreateQuizPassingCommandResult> Handle(CreateQuizPassingCommand request, CancellationToken cancellationToken)
        {
            var quizPassing = _mapper.Map<QuizPassingEntity>(request);
            quizPassing.PassingDate = DateTime.Now;

            _quizPassingContext.Add(quizPassing);
            await _quizPassingContext.SaveChangesAsync();

            return new CreateQuizPassingCommandResult { Success = true };
        }
    }
}
