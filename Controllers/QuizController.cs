using AspNetCoreVueStarter.Cqrs.Commands;
using AspNetCoreVueStarter.Cqrs.Queries;
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
        public async Task<ActionResult> GetQuizzes()
        {
            var result = await _mediator.Send(new QuizSummariesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{quizId}/details")]
        public async Task<ActionResult> GetQuizDetails([FromRoute] int quizId)
        {
            var result = await _mediator.Send(new QuizDetailsQuery { QuizId = quizId });
            return Ok(result);
        }

        [HttpGet]
        [Route("{quizId}/passing")]
        public async Task<ActionResult> GetQuizForPassing([FromRoute] int quizId)
        {
            var result = await _mediator.Send(new QuizPassingQuery { QuizId = quizId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuiz([FromBody] CreateQuizCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("{quizId}")]
        public async Task<ActionResult> UpdateQuiz([FromRoute] int quizId, [FromBody] UpdateQuizCommand request)
        {
            request.Id = quizId;

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{quizId}")]
        public async Task<ActionResult> DeleteQuiz([FromRoute] int quizId)
        {
            var result = await _mediator.Send(new DeleteQuizCommand { Id = quizId });
            return Ok(result);
        }
    }
}
