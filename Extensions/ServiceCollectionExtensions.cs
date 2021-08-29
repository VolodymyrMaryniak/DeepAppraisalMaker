using AspNetCoreVueStarter.Data.Repositories;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreVueStarter.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void RegisterRepositories(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IQuizRepository, QuizRepository>();
		}
	}
}
