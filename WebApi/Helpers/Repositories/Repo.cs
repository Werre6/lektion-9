using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Helpers.Repositories;

public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
{
	private readonly DataContext _context;

	protected Repo(DataContext context)
	{
		_context = context;
	}

	public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
	{
		return await _context.Set<TEntity>().AnyAsync(expression);
	}

	public virtual async Task<TEntity> AddAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;

	}

	public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
			return entity!;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}

	public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			var entities = await _context.Set<TEntity>().ToListAsync();
			return entities!;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}

	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var entities = await _context.Set<TEntity>().Where(expression).ToListAsync();
			return entities!;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}
}
