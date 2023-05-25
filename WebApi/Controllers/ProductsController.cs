using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductSchema schema)
		{
			if (ModelState.IsValid)
			{
				if (await _productService.AnyAsync(x => x.Name == schema.Name))
					return Conflict();

				var product = await _productService.CreateAsync(schema);
				if (product != null)
					return Created("", product);

				return Problem();
			}

			return BadRequest();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (id <= 0) 
				return BadRequest();

			var product = await _productService.GetAsync(x => x.Id == id);
			if (product != null)
				return Ok(product);

			return NotFound();
		}

		[HttpGet("/frombody")]
		public async Task<IActionResult> Get([FromBody] ProductSchema schema)
		{
			if (ModelState.IsValid)
			{
				var product = await _productService.GetAsync(x => x.Name == schema.Name);
				if (product != null)
					return Ok(product);

				return NotFound();
			}

			return BadRequest();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productService.GetAllAsync();
			if (products.Count() != 0)
				return Ok(products);

			return NotFound();
		}
	}
}
