using Microsoft.AspNetCore.Mvc;
using CharacterForgeApi.Data;
using CharacterForgeApi.Dtos;
using Microsoft.EntityFrameworkCore;
using CharacterForgeApi.Models;
using CharacterForgeApi.Models.Items;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CharacterForgeApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ItemsController : Controller
	{
		private readonly CharacterDbContext _context;

		public ItemsController(CharacterDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Item>> GetItems()
		{
			
		}


		public IActionResult Index()
		{
			return View();
		}
	}
}
