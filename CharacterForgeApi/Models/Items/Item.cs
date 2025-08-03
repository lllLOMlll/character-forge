using Microsoft.Identity.Client;

namespace CharacterForgeApi.Models.Items
{
	public abstract class Item
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public int Quantity { get; set; } = 1;
	}
}
