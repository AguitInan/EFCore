using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice01Personnage.Migrations
{
    public partial class UpdatePersonnageTableNameWithModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsDeVie = table.Column<int>(type: "int", nullable: false),
                    Armure = table.Column<int>(type: "int", nullable: false),
                    Degats = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombrePersonneTues = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnage");
        }
    }
}
