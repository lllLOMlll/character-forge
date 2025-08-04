using CharacterForgeApi.Enums;

namespace CharacterForgeApi.Models.Items
{
	public class Weapon : Equipment
	{
		public int Damage { get; set; }
		public DamageType? DamageType { get; set; }
		public int Range { get; set; }
	}
}
