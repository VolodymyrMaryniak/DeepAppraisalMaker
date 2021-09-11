using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators.Shared
{
    public class QuizValidator : AbstractValidator<Quiz>
    {
        private readonly IQuizRepository _quizRepository;

        public QuizValidator(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;

            RuleFor(x => x.Name).NotEmpty().MaximumLength(100)
                .MustAsync(HaveUniqueNameAsync).WithMessage("Quiz name must be unique.");

            RuleFor(x => x.Questions).NotEmpty()
                .Must(HaveUniqueTexts).WithMessage("Questions must be unique.");

            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionValidator());
        }

        private async Task<bool> HaveUniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            var quizExists = await _quizRepository.GetMany().AnyAsync(x => x.Name == name, cancellationToken);

            return !quizExists;
        }

        private static bool HaveUniqueTexts(List<Quiz.Question> questions)
        {
            var uniqueQuestionsCount = questions.Select(x => x.Text?.Trim()).Distinct().Count();

            return uniqueQuestionsCount == questions.Count;
        }

        private class QuestionValidator : AbstractValidator<Quiz.Question>
        {
            public QuestionValidator()
            {
                RuleFor(x => x.Text).NotEmpty().MaximumLength(300);

                RuleFor(x => x.AnswerOptions)
                    .NotEmpty()
                    .Must(HaveUniqueTexts).WithMessage("Answer options must be unique.");

                RuleForEach(x => x.AnswerOptions)
                    .SetValidator(new AnswerOptionValidator());
            }

            private static bool HaveUniqueTexts(List<Quiz.AnswerOption> answerOptions)
            {
                var uniqueAnswerOptionsCount = answerOptions.Select(x => x.Text?.Trim()).Distinct().Count();

                return uniqueAnswerOptionsCount == answerOptions.Count;
            }
        }

        private class AnswerOptionValidator : AbstractValidator<Quiz.AnswerOption>
        {
            public AnswerOptionValidator()
            {
                RuleFor(x => x.Text).NotEmpty().MaximumLength(100);
            }
        }
    }
}
