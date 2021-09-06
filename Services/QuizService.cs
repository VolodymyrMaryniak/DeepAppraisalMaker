using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using AspNetCoreVueStarter.Models.Shared;
using AspNetCoreVueStarter.Models.ViewModels;
using AspNetCoreVueStarter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<OperationResult> CreateQuizAsync(Quiz quiz)
        {
            var quizEntity = new QuizEntity
            {
                Name = quiz.Name,
                Questions = quiz.Questions.Select(q => new QuestionEntity
                {
                    QuestionText = q.Text,
                    AnswerOptions = q.AnswerOptions.Select(o => new AnswerOptionEntity
                    {
                        AnswerOptionText = o.Text,
                        IsCorrectAnswer = o.IsCorrectAnswer
                    }).ToList()
                }).ToList(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _quizRepository.AddAsync(quizEntity);

            return new OperationResult {Success = true};
        }

        public async Task<OperationResult> UpdateQuizAsync(int quizId, Quiz quiz)
        {
            var quizEntity = await _quizRepository.GetMany()
                .Include(x => x.Questions)
                .ThenInclude(x => x.AnswerOptions)
                .FirstOrDefaultAsync(x => x.Id == quizId);

            quizEntity.Name = quiz.Name;

            // Delete not provided questions
            quizEntity.Questions = quizEntity.Questions.Where(x => quiz.Questions.Any(q => q.Text == x.QuestionText)).ToList();

            // Update or create questions
            foreach (var question in quiz.Questions)
            {
                var existingQuestion = quizEntity.Questions.FirstOrDefault(x => x.QuestionText == question.Text);
                if (existingQuestion != null)
                {
                    UpdateQuestion(existingQuestion, question);
                }
                else
                {
                    quizEntity.Questions.Add(CreateQuestion(question));
                }
            }

            // Save changes
            if (_quizRepository.HasChanges())
            {
                quizEntity.ModifiedDate = DateTime.Now;
                await _quizRepository.UpdateAsync();
            }

            return new OperationResult {Success = true};
        }

        private void UpdateQuestion(QuestionEntity questionEntity, Question question)
        {
            // Delete not provided answer options
            questionEntity.AnswerOptions = questionEntity.AnswerOptions.Where(x => question.AnswerOptions.Any(o => o.Text == x.AnswerOptionText)).ToList();

            // Update or create answer options
            foreach (var answerOption in question.AnswerOptions)
            {
                var existingAnswerOption = questionEntity.AnswerOptions.FirstOrDefault(x => x.AnswerOptionText == answerOption.Text);
                if (existingAnswerOption != null)
                {
                    UpdateAnswerOption(existingAnswerOption, answerOption);
                }
                else
                {
                    questionEntity.AnswerOptions.Add(CreateAnswerOption(answerOption));
                }
            }
        }

        private QuestionEntity CreateQuestion(Question question)
        {
            return new QuestionEntity
            {
                QuestionText = question.Text,
                AnswerOptions = question.AnswerOptions.Select(CreateAnswerOption).ToList()
            };
        }

        private void UpdateAnswerOption(AnswerOptionEntity answerOptionEntity, AnswerOption answerOption)
        {
            answerOptionEntity.IsCorrectAnswer = answerOption.IsCorrectAnswer;
        }

        private AnswerOptionEntity CreateAnswerOption(AnswerOption answerOption)
        {
            return new AnswerOptionEntity
            {
                AnswerOptionText = answerOption.Text,
                IsCorrectAnswer = answerOption.IsCorrectAnswer
            };
        }
    }
}
