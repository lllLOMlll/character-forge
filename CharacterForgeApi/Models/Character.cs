﻿namespace CharacterForgeApi.Models
{
	public class Character
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Race { get; set; } = string.Empty;
		public string Class { get; set; } = string.Empty;

		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Constitution { get; set; }
		public int Intelligence { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }
	}
}
