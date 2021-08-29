using AspNetCoreVueStarter.Data.Models;
using AspNetCoreVueStarter.Data.Repositories.Base;
using AspNetCoreVueStarter.Data.Repositories.Interfaces;

namespace AspNetCoreVueStarter.Data.Repositories
{
	public class QuizRepository : BaseRepository<QuizEntity>, IQuizRepository
	{
		public QuizRepository(DamDbContext dbContext) : base(dbContext)
		{
		}
	}
}
