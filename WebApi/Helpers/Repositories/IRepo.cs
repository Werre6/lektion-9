using System.Linq.Expressions;

namespace WebApi.Helpers.Repositories
{
	public interface IRepo<TEntity> where TEntity : class
	{
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
		Task<TEntity> AddAsync(TEntity entity);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
	}
}