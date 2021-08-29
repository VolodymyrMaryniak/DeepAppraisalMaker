using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models.Shared;
using AspNetCoreVueStarter.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Controllers
{
	[ApiController]
	[Route("api/quizzes")]
	public class QuizController : ControllerBase
	{
		private readonly List<EditQuizViewModel> _quizzes = new List<EditQuizViewModel>
		{
			new EditQuizViewModel
			{
				Id = 1,
				Name = "Math test",
				CreatedAt = new DateTime(2021, 7, 25),
				ModifiedAt = new DateTime(2021, 8, 5),
				Questions = new List<Question>
				{
					new Question
					{
						Text = "2 + 2 = ",
						AnswerOptions = new List<AnswerOption>
						{
							new AnswerOption {Text = "1", IsCorrectAnswer = false},
							new AnswerOption {Text = "2", IsCorrectAnswer = false},
							new AnswerOption {Text = "3", IsCorrectAnswer = false},
							new AnswerOption {Text = "4", IsCorrectAnswer = true},
							new AnswerOption {Text = "5", IsCorrectAnswer = false}
						}
					},
					new Question
					{
						Text = "1 + 2 = ",
						AnswerOptions = new List<AnswerOption>
						{
							new AnswerOption {Text = "1", IsCorrectAnswer = false},
							new AnswerOption {Text = "2", IsCorrectAnswer = false},
							new AnswerOption {Text = "3", IsCorrectAnswer = true},
							new AnswerOption {Text = "4", IsCorrectAnswer = false}
						}
					}
				}
			},
			new EditQuizViewModel
			{
				Id = 2,
				Name = "Biology test",
				CreatedAt = new DateTime(2021, 7, 26),
				ModifiedAt = new DateTime(2021, 7, 26),
				Questions = new List<Question>
				{
					new Question
					{
						Text = "What is biology?",
						AnswerOptions = new List<AnswerOption>
						{
							new AnswerOption {Text = "...", IsCorrectAnswer = false},
							new AnswerOption {Text = "Biology is the scientific study of life.", IsCorrectAnswer = true},
							new AnswerOption {Text = "58", IsCorrectAnswer = false}
						}
					}
				}
			}
		};

		private readonly IQuizRepository _quizRepository;

		public QuizController(IQuizRepository quizRepository)
		{
			_quizRepository = quizRepository;
		}

		[HttpGet]
		public async Task<List<QuizSummaryViewModel>> GetQuizzes()
		{
			var quizEntities = await _quizRepository.GetMany().ToListAsync();

			return quizEntities.Select(x => new QuizSummaryViewModel
			{
				Id = x.Id,
				Name = x.Name,
				CreatedAt = x.CreatedDate,
				ModifiedAt = x.ModifiedDate
			}).ToList();
		}

		[HttpGet]
		[Route("{quizId}/details")]
		public EditQuizViewModel GetQuizDetails([FromRoute] int quizId)
		{
			return _quizzes.FirstOrDefault(x => x.Id == quizId);
		}
	}
}
