using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
	public interface IDataContext
	{
		DbSet<ProductEntity> Products { get; set; }
	}
}