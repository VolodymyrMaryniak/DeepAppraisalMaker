using AspNetCoreVueStarter.Cqrs.Commands;
using AspNetCoreVueStarter.Cqrs.Commands.Validators;
using AspNetCoreVueStarter.Cqrs.Commands.Validators.Shared;
using AspNetCoreVueStarter.Data.Repositories;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreVueStarter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizRepository, QuizRepository>();
        }

        public static void RegisterValidators(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<Quiz>, QuizValidator>();
            serviceCollection.AddTransient<IValidator<CreateQuizCommand>, CreateQuizCommandValidator>();
            serviceCollection.AddTransient<IValidator<UpdateQuizCommand>, UpdateQuizCommandValidator>();
        }
    }
}
