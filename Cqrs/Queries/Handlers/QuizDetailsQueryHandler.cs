using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static AspNetCoreVueStarter.Cqrs.Queries.Results.QuizDetailsQueryResult;

namespace AspNetCoreVueStarter.Cqrs.Queries.Handlers
{
    public class QuizDetailsQueryHandler : IRequestHandler<QuizDetailsQuery, QuizDetailsQueryResult>
    {
        private readonly IQuizRepository _quizRepository;
        public QuizDetailsQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<QuizDetailsQueryResult> Handle(QuizDetailsQuery request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany()
                 .Include(x => x.Questions)
                 .ThenInclude(x => x.AnswerOptions)
                 .Where(x => x.Id == request.QuizId)
                 .FirstOrDefaultAsync(cancellationToken);

            if (quizEntity == null)
                return null;

            return new QuizDetailsQueryResult
            {
                Id = quizEntity.Id,
                Name = quizEntity.Name,
                CreatedAt = quizEntity.CreatedDate,
                ModifiedAt = quizEntity.ModifiedDate,
                Questions = quizEntity.Questions.Select(q => new Question
                {
                    Text = q.QuestionText,
                    AnswerOptions = q.AnswerOptions.Select(o => new AnswerOption
                    {
                        Text = o.AnswerOptionText,
                        IsCorrectAnswer = o.IsCorrectAnswer
                    }).ToList()
                }).ToList()
            };
        }
    }
}
