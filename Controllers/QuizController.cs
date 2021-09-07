using AspNetCoreVueStarter.Cqrs.Commands;
using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Cqrs.Queries;
using AspNetCoreVueStarter.Cqrs.Queries.Results;
using AspNetCoreVueStarter.Models;
using AspNetCoreVueStarter.Models.Shared;
using AspNetCoreVueStarter.Models.ViewModels;
using AspNetCoreVueStarter.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Controllers
{
    [ApiController]
	[Route("api/quizzes")]
	public class QuizController : ControllerBase
	{
        private readonly IQuizService _quizService;
        private readonly IMediator _mediator;

		public QuizController(IQuizService quizService, IMediator mediator)
		{
            _quizService = quizService;
            _mediator = mediator;
        }

		[HttpGet]
		public async Task<QuizSummariesQueryResult> GetQuizzes()
        {
            return await _mediator.Send(new QuizSummariesQuery());
        }

		[HttpGet]
		[Route("{quizId}/details")]
		public async Task<EditQuizViewModel> GetQuizDetails([FromRoute] int quizId)
        {
            return await _quizService.GetQuizDetailsAsync(quizId);
        }

        [HttpPost]
        public async Task<CreateQuizCommandResult> CreateQuiz([FromBody] CreateQuizCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [Route("{quizId}")]
        public async Task<OperationResult> UpdateQuiz([FromRoute] int quizId, [FromBody] Quiz quiz)
        {
            return await _quizService.UpdateQuizAsync(quizId, quiz);
        }
    }
}
