using AspNetCoreVueStarter.Models;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators.Shared
{
    public class QuizValidator : AbstractValidator<Quiz>
    {
        public QuizValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Questions).NotEmpty()
                .Must(HaveUniqueTexts).WithMessage("Questions must be unique.");

            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionValidator());
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
