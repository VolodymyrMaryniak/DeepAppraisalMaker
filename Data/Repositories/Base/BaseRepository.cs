using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Data.Repositories.Base
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DamDbContext _dbContext;

		public BaseRepository(DamDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TEntity> GetMany()
		{
			return _dbContext.Set<TEntity>();
		}

		public async Task AddAsync(TEntity entity, bool saveChanges)
		{
			_dbContext.Set<TEntity>().Add(entity);

			if (saveChanges)
				await _dbContext.SaveChangesAsync();
		}

		public Task UpdateAsync()
		{
			return _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntity entity, bool saveChanges)
		{
			_dbContext.Set<TEntity>().Remove(entity);

			if (saveChanges)
				await _dbContext.SaveChangesAsync();
		}

		public bool HasChanges()
		{
			return _dbContext.ChangeTracker.HasChanges();
		}
	}
}
