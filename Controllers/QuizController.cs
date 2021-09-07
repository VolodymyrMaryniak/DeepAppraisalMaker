using AspNetCoreVueStarter.Cqrs;
using AspNetCoreVueStarter.Cqrs.Commands;
using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Cqrs.Queries;
using AspNetCoreVueStarter.Cqrs.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Controllers
{
    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<QuizSummariesQueryResult> GetQuizzes()
        {
            return await _mediator.Send(new QuizSummariesQuery());
        }

        [HttpGet]
        [Route("{quizId}/details")]
        public async Task<QuizDetailsQueryResult> GetQuizDetails([FromRoute] int quizId)
        {
            return await _mediator.Send(new QuizDetailsQuery { Id = quizId });
        }

        [HttpPost]
        public async Task<CreateQuizCommandResult> CreateQuiz([FromBody] CreateQuizCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [Route("{quizId}")]
        public async Task<UpdateQuizCommandResult> UpdateQuiz([FromBody] UpdateQuizCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
