using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreateQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;

        public CreateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<CreateQuizCommandResult> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = new QuizEntity
            {
                Name = request.QuizName,
                Questions = request.Questions.Select(q => new QuestionEntity
                {
                    QuestionText = q.Text,
                    AnswerOptions = q.AnswerOptions.Select(o => new AnswerOptionEntity
                    {
                        AnswerOptionText = o.Text,
                        IsCorrectAnswer = o.IsCorrectAnswer
                    }).ToList()
                }).ToList(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _quizRepository.AddAsync(quizEntity);

            return new CreateQuizCommandResult {Success = true};
        }
    }
}
