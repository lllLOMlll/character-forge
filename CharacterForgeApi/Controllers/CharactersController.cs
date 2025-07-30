using CharacterForgeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterForgeApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharactersController : ControllerBase
	{
		private static readonly List<Character> characters = new()
	{
		new Character
		{
			Id = 1,
			Name = "Arthas",
			Race = "Humain",
			Class = "Paladin",
			Strength = 18,
			Dexterity = 12,
			Constitution = 16,
			Intelligence = 14,
			Wisdom = 10,
			Charisma = 15
		},
		new Character
		{
			Id = 2,
			Name = "Zarok",
			Race = "Elfe",
			Class = "Wizard",
			Strength = 8,
			Dexterity = 14,
			Constitution = 10,
			Intelligence = 20,
			Wisdom = 16,
			Charisma = 12
		}
	};

		[HttpGet]
		public ActionResult<IEnumerable<Character>> GetAll()
		{
			return Ok(characters);
		}

		[HttpGet("searchByClass")]
		public ActionResult<IEnumerable<Character>> SearchByClass([FromQuery] string characterClass)
		{
			if (string.IsNullOrEmpty(characterClass))
				return BadRequest("Class name cannot be empty.");

			var result = characters
				.Where(c => c.Class.Contains(characterClass, StringComparison.OrdinalIgnoreCase))
				.ToList();

			return Ok(result);
		}

		
	

	}
}
