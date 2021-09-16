using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        private readonly IQuizRepository _quizRepository;

        public CreateQuizCommandValidator(IValidator<Quiz> quizValidator, IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;

            RuleFor(x => x.Name)
                .MustAsync(HaveUniqueNameAsync)
                .WithMessage("Quiz name must be unique.");

            RuleFor(x => x).SetValidator(quizValidator);
        }

        private async Task<bool> HaveUniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            var quizExists = await _quizRepository.GetMany().Where(x => x.IsActive == true).AnyAsync(x => x.Name == name, cancellationToken);

            return !quizExists;
        }
    }
}
