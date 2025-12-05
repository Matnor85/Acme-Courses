using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class Femtiotrettonde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elever",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utbildningar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utbildningar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kontaktuppgifter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontaktTyp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktuppgifter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kontaktuppgifter_Elever_ElevID",
                        column: x => x.ElevID,
                        principalTable: "Elever",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevUtbildning",
                columns: table => new
                {
                    EleverID = table.Column<int>(type: "int", nullable: false),
                    UtbildningarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevUtbildning", x => new { x.EleverID, x.UtbildningarID });
                    table.ForeignKey(
                        name: "FK_ElevUtbildning_Elever_EleverID",
                        column: x => x.EleverID,
                        principalTable: "Elever",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevUtbildning_Utbildningar_UtbildningarID",
                        column: x => x.UtbildningarID,
                        principalTable: "Utbildningar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtbildningID = table.Column<int>(type: "int", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kurser_Utbildningar_UtbildningID",
                        column: x => x.UtbildningID,
                        principalTable: "Utbildningar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Elever",
                columns: new[] { "ID", "Efternamn", "Förnamn" },
                values: new object[,]
                {
                    { 1, "Andersson", "Anna" },
                    { 2, "Berg", "Björn" },
                    { 3, "Eriksson", "Erik" },
                    { 4, "Svensson", "Sara" },
                    { 5, "Lind", "Lina" },
                    { 6, "Olsson", "Oskar" }
                });

            migrationBuilder.InsertData(
                table: "Utbildningar",
                columns: new[] { "ID", "Beskrivning", "Namn" },
                values: new object[,]
                {
                    { 1, "Backend-Utvecklare", "BUV25" },
                    { 2, "Frontend-Utvecklare", "FUV25" },
                    { 3, "Fullstack-Utvecklare", "FSUV25" }
                });

            migrationBuilder.InsertData(
                table: "ElevUtbildning",
                columns: new[] { "EleverID", "UtbildningarID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Kontaktuppgifter",
                columns: new[] { "ID", "ElevID", "KontaktInfo", "KontaktTyp" },
                values: new object[,]
                {
                    { 1, 1, "anna.andersson@example.com", "E-post" },
                    { 2, 1, "070-1111111", "Telefon" },
                    { 3, 2, "bjorn.berg@example.com", "E-post" },
                    { 4, 2, "070-2222222", "Telefon" },
                    { 5, 3, "erik.eriksson@example.com", "E-post" },
                    { 6, 3, "070-3333333", "Telefon" },
                    { 7, 4, "sara.svensson@example.com", "E-post" },
                    { 8, 4, "070-4444444", "Telefon" },
                    { 9, 5, "lina.lind@example.com", "E-post" },
                    { 10, 5, "070-5555555", "Telefon" },
                    { 11, 6, "oskar.olsson@example.com", "E-post" },
                    { 12, 6, "070-6666666", "Telefon" }
                });

            migrationBuilder.InsertData(
                table: "Kurser",
                columns: new[] { "ID", "Beskrivning", "Namn", "SlutDatum", "StartDatum", "UtbildningID" },
                values: new object[,]
                {
                    { 1, "Introduktion till C# och .NET", "C# Grund", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "SQL Server och EF Core", "SQL Grund", new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "HTML, CSS och JavaScript", "Frontend 1", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Komponenter och state", "React Grund", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, "Bygg en komplett webbapplikation", "Fullstack Projekt", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, "CI/CD och deployment", "DevOps Introduktion", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElevUtbildning_UtbildningarID",
                table: "ElevUtbildning",
                column: "UtbildningarID");

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktuppgifter_ElevID",
                table: "Kontaktuppgifter",
                column: "ElevID");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_UtbildningID",
                table: "Kurser",
                column: "UtbildningID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElevUtbildning");

            migrationBuilder.DropTable(
                name: "Kontaktuppgifter");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Utbildningar");
        }
    }
}
