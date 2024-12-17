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
