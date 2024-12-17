using Microsoft.AspNetCore.Mvc;
using RenderDrinkAPI.DataAccessLayer;
using RenderDrinkAPI.Model;

namespace RenderDrinkAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyAPIController : ControllerBase
	{
		private readonly SupabaseService _supabaseService;

		// Fixed the constructor name typo here
		public MyAPIController(SupabaseService supabaseService)
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
				List<Drink> drinks = _supabaseService.GetDrinks();

				return Ok(drinks);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
