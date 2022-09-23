using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikerId);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.GebruikerId);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    ReserveringId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.AttractieId);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FavorietAttractieId = table.Column<int>(type: "INTEGER", nullable: true),
                    BegeleiderGebruikerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.GebruikerId);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_FavorietAttractieId",
                        column: x => x.FavorietAttractieId,
                        principalTable: "Attracties",
                        principalColumn: "AttractieId");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_BegeleiderGebruikerId",
                        column: x => x.BegeleiderGebruikerId,
                        principalTable: "Gasten",
                        principalColumn: "GebruikerId");
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    OnderhoudId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Probleem = table.Column<string>(type: "TEXT", nullable: false),
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.OnderhoudId);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attracties_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attracties",
                        principalColumn: "AttractieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    GastId = table.Column<int>(type: "INTEGER", nullable: false),
                    LaatstBezochteUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Coordinaat_X = table.Column<int>(type: "INTEGER", nullable: false),
                    Coordinaat_Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastInfos_Gasten_GastId",
                        column: x => x.GastId,
                        principalTable: "Gasten",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gastGebruikerId = table.Column<int>(type: "INTEGER", nullable: true),
                    dateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ReserveringId);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gasten_gastGebruikerId",
                        column: x => x.gastGebruikerId,
                        principalTable: "Gasten",
                        principalColumn: "GebruikerId");
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoudCoordineert",
                columns: table => new
                {
                    CoordineertGebruikerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoordineertOnderhoudId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoudCoordineert", x => new { x.CoordineertGebruikerId, x.CoordineertOnderhoudId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoudCoordineert_Medewerkers_CoordineertGebruikerId",
                        column: x => x.CoordineertGebruikerId,
                        principalTable: "Medewerkers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoudCoordineert_Onderhoud_CoordineertOnderhoudId",
                        column: x => x.CoordineertOnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "OnderhoudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoudDoet",
                columns: table => new
                {
                    DoetGebruikerId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoetOnderhoudId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoudDoet", x => new { x.DoetGebruikerId, x.DoetOnderhoudId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoudDoet_Medewerkers_DoetGebruikerId",
                        column: x => x.DoetGebruikerId,
                        principalTable: "Medewerkers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoudDoet_Onderhoud_DoetOnderhoudId",
                        column: x => x.DoetOnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "OnderhoudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attracties_ReserveringId",
                table: "Attracties",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_BegeleiderGebruikerId",
                table: "Gasten",
                column: "BegeleiderGebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_FavorietAttractieId",
                table: "Gasten",
                column: "FavorietAttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_GastInfos_GastId",
                table: "GastInfos",
                column: "GastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoudCoordineert_CoordineertOnderhoudId",
                table: "MedewerkerOnderhoudCoordineert",
                column: "CoordineertOnderhoudId");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoudDoet_DoetOnderhoudId",
                table: "MedewerkerOnderhoudDoet",
                column: "DoetOnderhoudId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_AttractieId",
                table: "Onderhoud",
                column: "AttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_gastGebruikerId",
                table: "Reserveringen",
                column: "gastGebruikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attracties_Reserveringen_ReserveringId",
                table: "Attracties",
                column: "ReserveringId",
                principalTable: "Reserveringen",
                principalColumn: "ReserveringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attracties_Reserveringen_ReserveringId",
                table: "Attracties");

            migrationBuilder.DropTable(
                name: "GastInfos");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoudCoordineert");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoudDoet");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
