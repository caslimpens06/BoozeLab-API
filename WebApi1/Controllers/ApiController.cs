using Microsoft.AspNetCore.Mvc;
using WebApi1.Model;
using RenderDrinkAPI.DataAccessLayer;

namespace Render_Drink_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyApiController : ControllerBase
	{
		private readonly SupabaseService _supabaseService;

		public MyApiController(SupabaseService supabaseService)
		{
			_supabaseService = supabaseService;
		}

		// GET api/myapi/drinks
		[HttpGet("drinks")]
		public IActionResult GetDrinks()
		{
			try
			{
				
				// Get drinks from the Supabase database
				//List<Drink> drinks = _supabaseService.GetDrinks();

				List<Drink> drinks = new List<Drink>()
				{
					new Drink(1, "Coca-Cola", "Soda", "iVBORw0KGgoAAAANSUhEUgAAAAUA..."), // Example base64 string
					new Drink(2, "Orange Juice", "Juice", "iVBORw0KGgoAAAANSUhEUgAAAAUA..."),
					new Drink(3, "Water", "Water", "iVBORw0KGgoAAAANSUhEUgAAAAUA..."),
					new Drink(4, "Coffee", "Hot Beverage", "iVBORw0KGgoAAAANSUhEUgAAAAUA..."),
					new Drink(5, "Tea", "Hot Beverage", "iVBORw0KGgoAAAANSUhEUgAAAAUA...")
				};

				return Ok(drinks);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
