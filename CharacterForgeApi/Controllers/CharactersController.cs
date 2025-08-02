using CharacterForgeApi.Models;
using Microsoft.AspNetCore.Mvc;
using CharacterForgeApi.Data;
using Microsoft.EntityFrameworkCore;
using CharacterForgeApi.Dtos;

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
			var characters = await _context.Characters.ToListAsync();

			var dtos = characters.Select(c => new CharacterDto
			{
				Id = c.Id,
				Name = c.Name,
				Race = c.Race,
				Class = c.Class,
				Strength = c.Strength,
				Dexterity = c.Dexterity,
				Constitution = c.Constitution,
				Intelligence = c.Intelligence,
				Wisdom = c.Wisdom,
				Charisma = c.Charisma

			});

			return Ok(dtos);
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
		public async Task<ActionResult<Character>> Create([FromBody] CreateCharacterDto dto)
		{
			if (dto == null)
			{
				return BadRequest("Character data is required.");
			}

			var character = new Character
			{
				Name = dto.Name,
				Race = dto.Race,
				Class = dto.Class,
				Strength = dto.Strength,
				Dexterity = dto.Dexterity,
				Constitution = dto.Constitution,
				Intelligence = dto.Intelligence,
				Wisdom = dto.Wisdom,
				Charisma = dto.Charisma
			};

			// Map the DTO to the Character model
			var resultDto = new CharacterDto
			{
				Id = character.Id,
				Name = character.Name,
				Race = character.Race,
				Class = character.Class,
				Strength = character.Strength,
				Dexterity = character.Dexterity,
				Constitution = character.Constitution,
				Intelligence = character.Intelligence,
				Wisdom = character.Wisdom,
				Charisma = character.Charisma
			};

			_context.Characters.Add(character);
			await _context.SaveChangesAsync();

			// Return resultDto with the created character's ID instead of the full character object
			return CreatedAtAction(nameof(GetAll), new { id = character.Id }, resultDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCharacter(int id, [FromBody] UpdateCharacterDto dto)
		{
			var character = await _context.Characters.FindAsync(id);
			if (character == null)
			{
				return NotFound();
			}

			character.Name = dto.Name;
			character.Race = dto.Race;
			character.Class = dto.Class;
			character.Strength = dto.Strength;
			character.Dexterity = dto.Dexterity;
			character.Constitution = dto.Constitution;
			character.Intelligence = dto.Intelligence;
			character.Wisdom = dto.Wisdom;
			character.Charisma = dto.Charisma;

			await _context.SaveChangesAsync();
			return NoContent();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCharacter(int id)
		{
			var character = await _context.Characters.FindAsync(id);
			if (character == null)
			{
				return NotFound();
			}

			_context.Characters.Remove(character);
			await _context.SaveChangesAsync();
			return NoContent();
		}


	}
}
