using AspNetCoreVueStarter.Cqrs.Commands.Results;
using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static AspNetCoreVueStarter.Cqrs.Commands.UpdateQuizCommand;

namespace AspNetCoreVueStarter.Cqrs.Commands.Handlers
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, UpdateQuizCommandResult>
    {
        private readonly IQuizRepository _quizRepository;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<UpdateQuizCommandResult> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = await _quizRepository.GetMany()
                 .Include(x => x.Questions)
                 .ThenInclude(x => x.AnswerOptions)
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            quizEntity.Name = request.QuizName;

            // Delete not provided questions
            quizEntity.Questions = quizEntity.Questions.Where(x => request.Questions.Any(q => q.Text == x.QuestionText)).ToList();

            // Update or create questions
            foreach (var question in request.Questions)
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

            return new UpdateQuizCommandResult { Success = true };
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

        private static void UpdateAnswerOption(AnswerOptionEntity answerOptionEntity, AnswerOption answerOption)
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
