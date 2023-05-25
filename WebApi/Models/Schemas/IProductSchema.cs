namespace WebApi.Models.Schemas;

public interface IProductSchema
{
	string? Description { get; set; }
	string Name { get; set; }
	decimal Price { get; set; }
}
