using Microsoft.EntityFrameworkCore;
using CharacterForgeApi.Models;
using Microsoft.Identity.Client;
using CharacterForgeApi.Models.Items;

namespace CharacterForgeApi.Data;

public class CharacterDbContext : DbContext
{
	public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options) { }

	public DbSet<Character> Characters => Set<Character>();

	public DbSet<Item> Items => Set<Item>();
	public DbSet<Potion> Potions => Set<Potion>();
	public DbSet<Armor> Amors => Set<Armor>();
	public DbSet<Weapon> Weapons => Set<Weapon>();
	public DbSet<Equipment> Equipment => Set<Equipment>(); // Optionnal but useful!

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder
			.Entity<Item>()
			.HasDiscriminator<string>("ItemType")
			.HasValue<Potion>("Potion")
			.HasValue<Armor>("Armor")
			.HasValue<Weapon>("Weapon");
	}
}
