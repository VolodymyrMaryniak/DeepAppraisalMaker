using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Queries
{
    public class QuizDetailsQuery : IRequest<QuizDetailsQueryResult>
    {
        public int QuizId { get; set; }
    }
}
