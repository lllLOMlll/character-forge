using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterForgeApi.Migrations
{
    /// <inheritdoc />
    public partial class FixNameIsEquipped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isEquipped",
                table: "Items",
                newName: "IsEquipped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEquipped",
                table: "Items",
                newName: "isEquipped");
        }
    }
}
