using AspNetCoreVueStarter.Cqrs.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Controllers
{
    [ApiController]
    [Route("api/passings")]
    public class QuizPassingController : Controller
    {
        private readonly IMediator _mediator;

        public QuizPassingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuiz([FromBody] CreateQuizPassingCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
