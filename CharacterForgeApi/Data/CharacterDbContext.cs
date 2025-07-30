using Microsoft.EntityFrameworkCore;
using CharacterForgeApi.Models;

namespace CharacterForgeApi.Data;

public class CharacterDbContext : DbContext
{
	public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options) { }

	public DbSet<Character> Characters => Set<Character>();
}
