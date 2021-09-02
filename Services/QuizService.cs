using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models.Shared;
using AspNetCoreVueStarter.Models.ViewModels;
using AspNetCoreVueStarter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<QuizSummaryViewModel>> GetQuizSummaryViewModelsAsync()
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

        public async Task<EditQuizViewModel> GetQuizDetailsAsync(int quizId)
        {
            var quizEntity = await _quizRepository.GetMany()
                .Include(x => x.Questions)
                .ThenInclude(x => x.AnswerOptions)
                .Where(x => x.Id == quizId)
                .FirstOrDefaultAsync();

            if (quizEntity == null)
                return null;

            return new EditQuizViewModel
            {
                Id = quizEntity.Id,
                Name = quizEntity.Name,
                CreatedAt = quizEntity.CreatedDate,
                ModifiedAt = quizEntity.ModifiedDate,
                Questions = quizEntity.Questions.Select(q => new Question
                {
                    Text = q.QuestionText,
                    AnswerOptions = q.AnswerOptions.Select(o => new AnswerOption
                    {
                        Text = o.AnswerOptionText,
                        IsCorrectAnswer = o.IsCorrectAnswer
                    }).ToList()
                }).ToList()
            };
        }
    }
}
