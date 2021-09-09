using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Questions).NotNull();

            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionValidator());
        }

        private class QuestionValidator : AbstractValidator<CreateQuizCommand.Question>
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

            private static bool HaveUniqueTexts(List<CreateQuizCommand.AnswerOption> answerOptions)
            {
                var uniqueAnswerOptionsCount = answerOptions.Select(x => x.Text?.Trim()).Distinct().Count();

                return uniqueAnswerOptionsCount == answerOptions.Count;
            }
        }

        private class AnswerOptionValidator : AbstractValidator<CreateQuizCommand.AnswerOption>
        {
            public AnswerOptionValidator()
            {
                RuleFor(x => x.Text).NotEmpty().MaximumLength(100);
            }
        }
    }
}
