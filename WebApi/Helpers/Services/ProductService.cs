using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepo;

	public ProductService(IProductRepository productRepo)
	{
		_productRepo = productRepo;
	}

	public Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		return _productRepo.AnyAsync(expression);
	}

	public async Task<Product> CreateAsync(ProductSchema schema)
	{
		try
		{
			if (!await _productRepo.AnyAsync(x => x.Name == schema.Name))
				return await _productRepo.AddAsync(schema);

		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}

	public async Task<IEnumerable<Product>> GetAllAsync()
	{
		try
		{
			var products = new List<Product>();
			foreach (var entity in await _productRepo.GetAllAsync())
				products.Add(entity);

			return products;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}

	public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		try
		{
			var products = new List<Product>();
			foreach (var entity in await _productRepo.GetAllAsync(expression))
				products.Add(entity);

			return products;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}

	public async Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		try
		{
			return await _productRepo.GetAsync(expression);
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;
	}
}
