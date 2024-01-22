using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    id_uzytkownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    data_urodzenia = table.Column<DateTime>(type: "date", nullable: false),
                    miasto = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    rodzaj = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.id_uzytkownik);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ksiazka = table.Column<int>(type: "int", nullable: false),
                    id_uzytkownik = table.Column<int>(type: "int", nullable: false),
                    data_wypozyczenia = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Wypozyczenia");
        }
    }
}
