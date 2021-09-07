using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Queries.Handlers
{
    public class QuizSummariesQueryHandler : IRequestHandler<QuizSummariesQuery, QuizSummariesQueryResult>
    {
        private readonly IQuizRepository _quizRepository;

        public QuizSummariesQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<QuizSummariesQueryResult> Handle(QuizSummariesQuery request, CancellationToken cancellationToken)
        {
            var quizEntities = await _quizRepository.GetMany().ToListAsync(cancellationToken);

            var quizSummaries = quizEntities
                .Select(x => new QuizSummariesQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedDate,
                    ModifiedAt = x.ModifiedDate
                }).FirstOrDefault();

            return quizSummaries;
        }
    }
}
