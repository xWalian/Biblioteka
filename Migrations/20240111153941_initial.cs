using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    id_ksiazka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_kategoria = table.Column<int>(type: "int", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wydawnictwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rok_wydania = table.Column<int>(type: "int", nullable: false),
                    ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.id_ksiazka);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ksiazki");
        }
    }
}
