using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice02HotelAgain.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_HotelId",
                table: "Clients",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Hotels_HotelId",
                table: "Clients",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Hotels_HotelId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_HotelId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Clients");
        }
    }
}
