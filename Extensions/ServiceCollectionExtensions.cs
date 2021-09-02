using AspNetCoreVueStarter.Data.Repositories;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using AspNetCoreVueStarter.Services;
using AspNetCoreVueStarter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreVueStarter.Extensions
{
    public static class ServiceCollectionExtensions
	{
		public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
			serviceCollection.AddTransient<IQuizRepository, QuizRepository>();
		}

        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuizService, QuizService>();
        }
	}
}
