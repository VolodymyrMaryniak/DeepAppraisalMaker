using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public QuizSummariesQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<QuizSummariesQueryResult> Handle(QuizSummariesQuery request, CancellationToken cancellationToken)
        {
            var quizEntities = await _quizRepository.GetMany().ToListAsync(cancellationToken);

            quizEntities = quizEntities.Where(x => x.IsActive == true).ToList();

            return _mapper.Map<QuizSummariesQueryResult>(quizEntities);
        }
    }
}
