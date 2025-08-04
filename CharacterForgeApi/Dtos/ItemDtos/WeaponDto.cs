namespace CharacterForgeApi.Dtos.ItemDtos
{
	public class WeaponDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public bool IsEquipped { get; set; }
		public int Weight { get; set; }
		public int Damage { get; set; }
		public string DamageType { get; set; } = string.Empty;
	}
}
