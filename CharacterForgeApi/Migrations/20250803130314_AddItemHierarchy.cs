using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterForgeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddItemHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AC = table.Column<int>(type: "int", nullable: true),
                    isEquipped = table.Column<bool>(type: "bit", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: true),
                    DamageTye = table.Column<int>(type: "int", nullable: true),
                    Range = table.Column<int>(type: "int", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
