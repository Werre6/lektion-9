using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities;

public class ProductEntity : IProductEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	[Required]
	public decimal Price { get; set; }


	public static implicit operator Product(ProductEntity entity)
	{
		try
		{
			return new Product
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				Price = entity.Price,
			};
		}
		catch (Exception ex) { Debug.WriteLine(ex); }
		return null!;
	}
}
