using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;

namespace AspNetCoreVueStarter.Cqrs.Queries
{
    public class QuizSummariesQuery : IRequest<QuizSummariesQueryResult>
    {
    }
}
