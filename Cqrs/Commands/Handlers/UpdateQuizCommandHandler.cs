using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Exceptions;
using AspNetCoreVueStarter.Services;
using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<UpdateQuizCommand> _validator;
        private readonly IMapper _mapper;
        private readonly QuizService _quizService;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository, IValidator<UpdateQuizCommand> validator, IMapper mapper, QuizService quizService)
        {
            _quizRepository = quizRepository;
            _validator = validator;
            _mapper = mapper;
            _quizService = quizService;
        }

        public async Task<UpdateQuizCommandResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var quizEntity = await _quizRepository.GetMany()
                 .Include(x => x.Questions)
                 .ThenInclude(x => x.AnswerOptions)
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (quizEntity == null)
                throw new NotFoundException();

            if (!await _quizService.QuizUsed(request.Id, cancellationToken))
            {
                _mapper.Map(request, quizEntity);
                quizEntity.ModifiedDate = DateTime.Now;

                await _quizRepository.UpdateAsync();

                return new UpdateQuizCommandResult { Success = true };
            }

            await _quizService.CreateQuiz(quizEntity);

            return new UpdateQuizCommandResult { Success = true };
        }
    }
}
