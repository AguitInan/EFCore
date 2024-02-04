using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice02HotelAgain.Migrations
{
    public partial class _4thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Chambres",
                columns: table => new
                {
                    ChambreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    NombreDeLits = table.Column<int>(type: "int", nullable: false),
                    Tarif = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambres", x => x.ChambreId);
                    table.ForeignKey(
                        name: "FK_Chambres_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationChambre",
                columns: table => new
                {
                    ChambreNumero = table.Column<int>(type: "int", nullable: false),
                    ReservationIdentifiant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationChambre", x => new { x.ChambreNumero, x.ReservationIdentifiant });
                    table.ForeignKey(
                        name: "FK_ReservationChambre_Chambres_ChambreNumero",
                        column: x => x.ChambreNumero,
                        principalTable: "Chambres",
                        principalColumn: "ChambreId");
                    table.ForeignKey(
                        name: "FK_ReservationChambre_Reservations_ReservationIdentifiant",
                        column: x => x.ReservationIdentifiant,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chambres_HotelId",
                table: "Chambres",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChambre_ReservationIdentifiant",
                table: "ReservationChambre",
                column: "ReservationIdentifiant");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationChambre");

            migrationBuilder.DropTable(
                name: "Chambres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
