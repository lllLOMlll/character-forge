using Microsoft.AspNetCore.Mvc;
using CharacterForgeApi.Data;
using CharacterForgeApi.Dtos;
using Microsoft.EntityFrameworkCore;
using CharacterForgeApi.Models;
using CharacterForgeApi.Models.Items;
using Microsoft.AspNetCore.Http.HttpResults;
using CharacterForgeApi.Dtos.ItemDtos;
using CharacterForgeApi.Enums;

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
		public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
		{
			var items = await _context.Items.ToListAsync();

			var itemDtos = items.Select(item => new ItemDto
			{
				Id = item.Id,
				Name = item.Name,
				Description = item.Description,
				ItemType = item.GetType().Name,
				Quantity = item.Quantity,

				IsEquipped = item is Equipment equipment ? equipment.IsEquipped : null,
				Weight = item is Equipment equipmentWithWeight ? equipmentWithWeight.Weight : null,
				Damage = item is Weapon weapon ? weapon.Damage : null,
				DamageType = item is Weapon weaponWithDamageType? weaponWithDamageType.DamageType?.ToString() : null,
				AC = item is Armor armor ? armor.AC : null,
				Effect = item is Potion potion ? potion.Effect : null
			}).ToList();

			return Ok(itemDtos);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Item>>> GetWeapons()
		{
			var items = await _context.Items.
				OfType<Weapon>()
				.ToListAsync();

			var weponDtos = items.Select(weapon => new WeaponDto
			{
				Id = weapon.Id,
				Name = weapon.Name,
				Description = weapon.Description,
				Quantity = weapon.Quantity,
				IsEquipped = weapon.IsEquipped,
				Weight = weapon.Weight,
				Damage = weapon.Damage,
				DamageType = weapon.DamageType?.ToString()
			}).ToList();

			return Ok(weponDtos);
		}




		public IActionResult Index()
		{
			return View();
		}
	}
}
