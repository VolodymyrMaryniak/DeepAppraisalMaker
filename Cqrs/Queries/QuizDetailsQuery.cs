using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVueStarter.Cqrs.Queries
{
    public class QuizDetailsQuery : IRequest<QuizDetailsQueryResult>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
