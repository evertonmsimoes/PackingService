using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PackingService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Largura = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "Id", "Altura", "Comprimento", "Largura", "Nome" },
                values: new object[,]
                {
                    { 1, 30, 80, 40, "Caixa 1" },
                    { 2, 80, 40, 50, "Caixa 2" },
                    { 3, 50, 60, 80, "Caixa 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boxes");
        }
    }
}
