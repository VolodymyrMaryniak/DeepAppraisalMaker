using AspNetCoreVueStarter.Models;
using FluentValidation;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class UpdateQuizCommandValidator : AbstractValidator<UpdateQuizCommand>
    {
        public UpdateQuizCommandValidator(IValidator<Quiz> quizValidator)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x).SetValidator(quizValidator);
        }
    }
}
