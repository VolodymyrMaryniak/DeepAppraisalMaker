using AspNetCoreVueStarter.Models.ViewModels;
using AspNetCoreVueStarter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Controllers
{
    [ApiController]
	[Route("api/quizzes")]
	public class QuizController : ControllerBase
	{
        private readonly IQuizService _quizService;

		public QuizController(IQuizService quizService)
		{
            _quizService = quizService;
		}

		[HttpGet]
		public async Task<List<QuizSummaryViewModel>> GetQuizzes()
        {
            return await _quizService.GetQuizSummaryViewModelsAsync();
		}

		[HttpGet]
		[Route("{quizId}/details")]
		public async Task<EditQuizViewModel> GetQuizDetails([FromRoute] int quizId)
        {
            return await _quizService.GetQuizDetailsAsync(quizId);
        }
	}
}
