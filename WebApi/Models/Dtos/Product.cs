namespace WebApi.Models.Dtos;

public class Product : IProduct
{
	public int? Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public decimal? Price { get; set; }
}
