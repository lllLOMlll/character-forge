namespace CharacterForgeApi.Models.Items
{
	public abstract class Equipment : Item
	{
		public bool IsEquipped { get; set; }
		public int Weight { get; set; }
	}
}
