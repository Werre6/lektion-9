using System.Linq.Expressions;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public interface IProductService
{
	Task<Product> CreateAsync(ProductSchema schema);
	Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression);
	Task<IEnumerable<Product>> GetAllAsync();
	Task<IEnumerable<Product>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression);
	Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression);
}
