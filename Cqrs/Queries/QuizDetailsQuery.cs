using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs
{
    public class QuizDetailsQuery : IRequest<QuizDetailsQueryResult>
    {
        public int Id { get; set; }
    }
}
