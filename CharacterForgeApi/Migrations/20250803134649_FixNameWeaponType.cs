using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterForgeApi.Migrations
{
    /// <inheritdoc />
    public partial class FixNameWeaponType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DamageTye",
                table: "Items",
                newName: "DamageType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "Items",
                newName: "DamageTye");
        }
    }
}
