namespace CharacterForgeApi.Models.Items
{
	public abstract class Equipment : Item
	{
		public bool isEquipped { get; set; }
		public int Weight { get; set; }
	}
}
