namespace WebApi.Models.Dtos
{
	public interface IProduct
	{
		string? Description { get; set; }
		int? Id { get; set; }
		string? Name { get; set; }
		decimal? Price { get; set; }
	}
}