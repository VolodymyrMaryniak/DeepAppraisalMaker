using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Queries
{
    public class QuizPassingQuery : IRequest<QuizPassingQueryResult>
    {
        public int QuizId { get; set; }
    }
}
