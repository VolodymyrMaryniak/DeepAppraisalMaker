using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Cqrs.Commands.Validators
{
    public class UpdateQuizCommandValidator : AbstractValidator<UpdateQuizCommand>
    {
        private readonly IQuizRepository _quizRepository;

        public UpdateQuizCommandValidator(IValidator<Quiz> quizValidator, IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;

            RuleFor(x => x.Name)
                .MustAsync((command, name, _, cancellationToken) => HaveUniqueNameAsync(name, command.Id, cancellationToken))
                .WithMessage("Quiz name must be unique.");

            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x).SetValidator(quizValidator);
        }
        private async Task<bool> HaveUniqueNameAsync(string name, int id, CancellationToken cancellationToken)
        {
            var quizExists = await _quizRepository.GetMany().Where(x => x.Id != id || x.IsActive == true).AnyAsync(x => x.Name == name, cancellationToken);

            return !quizExists;
        }
    }
}
