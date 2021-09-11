using AspNetCoreVueStarter.Models;
using FluentValidation;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator(IValidator<Quiz> quizValidator)
        {
            RuleFor(x => x).SetValidator(quizValidator);
        }
    }
}
