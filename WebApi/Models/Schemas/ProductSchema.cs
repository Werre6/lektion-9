using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class ProductSchema : IProductSchema
{
	[Required]
	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	[Required]
	public decimal Price { get; set; }


	public static implicit operator ProductEntity(ProductSchema schema)
	{
		try
		{
			return new ProductEntity
			{
				Name = schema.Name,
				Description = schema.Description,
				Price = schema.Price,
			};
		}
		catch (Exception ex) { Debug.WriteLine(ex); }
		return null!;
	}
}
