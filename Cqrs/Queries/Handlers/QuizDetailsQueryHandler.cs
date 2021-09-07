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
    public class QuizDetailsQueryHandler : IRequestHandler<QuizDetailsQuery, QuizDetailsQueryResult>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizDetailsQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<QuizDetailsQueryResult> Handle(QuizDetailsQuery request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany()
                 .Include(x => x.Questions)
                 .ThenInclude(x => x.AnswerOptions)
                 .Where(x => x.Id == request.QuizId)
                 .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<QuizDetailsQueryResult>(quizEntity);
        }
    }
}
