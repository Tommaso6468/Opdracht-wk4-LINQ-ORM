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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    AttractieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReserveringId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.AttractieId);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FavorietAttractieId = table.Column<int>(type: "int", nullable: true),
                    BegeleiderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_FavorietAttractieId",
                        column: x => x.FavorietAttractieId,
                        principalTable: "Attracties",
                        principalColumn: "AttractieId");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_BegeleiderId",
                        column: x => x.BegeleiderId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    OnderhoudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTimeBereik_Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_Eind = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Probleem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttractieId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GastId = table.Column<int>(type: "int", nullable: false),
                    LaatstBezochteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordinaat_X = table.Column<int>(type: "int", nullable: false),
                    Coordinaat_Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastInfos_Gasten_GastId",
                        column: x => x.GastId,
                        principalTable: "Gasten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gastId = table.Column<int>(type: "int", nullable: true),
                    dateTimeBereik_Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_Eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ReserveringId);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gasten_gastId",
                        column: x => x.gastId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud",
                columns: table => new
                {
                    CoordineertId = table.Column<int>(type: "int", nullable: false),
                    OnderhoudId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud", x => new { x.CoordineertId, x.OnderhoudId });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Medewerkers_CoordineertId",
                        column: x => x.CoordineertId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Onderhoud_OnderhoudId",
                        column: x => x.OnderhoudId,
                        principalTable: "Onderhoud",
                        principalColumn: "OnderhoudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attracties_ReserveringId",
                table: "Attracties",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_BegeleiderId",
                table: "Gasten",
                column: "BegeleiderId");

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
                name: "IX_MedewerkerOnderhoud_OnderhoudId",
                table: "MedewerkerOnderhoud",
                column: "OnderhoudId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_AttractieId",
                table: "Onderhoud",
                column: "AttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_gastId",
                table: "Reserveringen",
                column: "gastId");

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
                name: "MedewerkerOnderhoud");

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
