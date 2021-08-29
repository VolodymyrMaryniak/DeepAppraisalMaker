using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Data.Repositories.Base
{
	public interface IRepository<TEntity>
		where TEntity : class
	{
		IQueryable<TEntity> GetMany();
		Task AddAsync(TEntity entity, bool saveChanges = true);
		Task UpdateAsync();
		Task DeleteAsync(TEntity entity, bool saveChanges = true);
		bool HasChanges();
	}
}
