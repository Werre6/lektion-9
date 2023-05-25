namespace WebApi.Models.Entities
{
	public interface IProductEntity
	{
		string? Description { get; set; }
		int Id { get; set; }
		string Name { get; set; }
		decimal Price { get; set; }
	}
}