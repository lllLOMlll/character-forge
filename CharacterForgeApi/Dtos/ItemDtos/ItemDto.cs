namespace CharacterForgeApi.Dtos.ItemDtos
{
	public class ItemDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ItemType { get; set; } = string.Empty;
		public int Quantity { get; set; }

		// Optionnels selon le type
		public bool? IsEquipped { get; set; }
		public int? Weight { get; set; }

		// Weapon only
		public int? Damage { get; set; }
		public string? DamageType { get; set; }

		// Armor only
		public int? AC { get; set; }

		// Potion only
		public string? Effect { get; set; }
	}
}
