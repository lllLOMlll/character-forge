using CharacterForgeApi.Models;
using Microsoft.AspNetCore.Mvc;
using CharacterForgeApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CharacterForgeApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharactersController : ControllerBase
	{
		private readonly CharacterDbContext _context;

		public CharactersController(CharacterDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Character>>> GetAll()
		{
			return await _context.Characters.ToListAsync();
		}

			//[HttpGet("searchByClass")]
			//public ActionResult<IEnumerable<Character>> SearchByClass([FromQuery] string characterClass)
			//{
			//	if (string.IsNullOrEmpty(characterClass))
			//		return BadRequest("Class name cannot be empty.");

			//	var result = characters
			//		.Where(c => c.Class.Contains(characterClass, StringComparison.OrdinalIgnoreCase))
			//		.ToList();

			//	return Ok(result);
			//}

		[HttpPost]
		public async Task<ActionResult<Character>> Create(Character character)
		{
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAll), new { id = character.Id }, character);
		}



		}
}
