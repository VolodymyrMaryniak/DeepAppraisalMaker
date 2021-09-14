using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Queries.Handlers
{
    public class QuizPassingQueryHandler : IRequestHandler<QuizPassingQuery, QuizPassingQueryResult>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizPassingQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }
        public async Task<QuizPassingQueryResult> Handle(QuizPassingQuery request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany()
                  .Include(x => x.Questions)
                  .ThenInclude(x => x.AnswerOptions)
                  .Where(x => x.Id == request.QuizId)
                  .FirstOrDefaultAsync(cancellationToken);
            if (quizEntity == null)
                throw new NotFoundException();

            return _mapper.Map<QuizPassingQueryResult>(quizEntity);
        }
    }
}
