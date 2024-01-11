using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wydawnictwo",
                table: "Ksiazki",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");

            migrationBuilder.AlterColumn<string>(
                name: "tytul",
                table: "Ksiazki",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");

            migrationBuilder.AlterColumn<string>(
                name: "autor",
                table: "Ksiazki",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wydawnictwo",
                table: "Ksiazki",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "tytul",
                table: "Ksiazki",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "autor",
                table: "Ksiazki",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");
        }
    }
}
