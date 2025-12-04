using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class Newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontaktuppgifter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontaktTyp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktuppgifter", x => x.ID);
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
                name: "Elever",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktUppgiftID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Elever_Kontaktuppgifter_KontaktUppgiftID",
                        column: x => x.KontaktUppgiftID,
                        principalTable: "Kontaktuppgifter",
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

            migrationBuilder.InsertData(
                table: "Kontaktuppgifter",
                columns: new[] { "ID", "KontaktInfo", "KontaktTyp" },
                values: new object[,]
                {
                    { 1, "anna.andersson@example.com", "E-post" },
                    { 2, "070-1111111", "Telefon" },
                    { 3, "erik.eriksson@example.com", "E-post" },
                    { 4, "070-2222222", "Telefon" },
                    { 5, "lina.lind@example.com", "E-post" },
                    { 6, "070-3333333", "Telefon" }
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
                table: "Elever",
                columns: new[] { "ID", "Efternamn", "Förnamn", "KontaktUppgiftID" },
                values: new object[,]
                {
                    { 1, "Andersson", "Anna", 1 },
                    { 2, "Berg", "Björn", 2 },
                    { 3, "Eriksson", "Erik", 3 },
                    { 4, "Svensson", "Sara", 4 },
                    { 5, "Lind", "Lina", 5 },
                    { 6, "Olsson", "Oskar", 6 }
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
                name: "IX_Elever_KontaktUppgiftID",
                table: "Elever",
                column: "KontaktUppgiftID");

            migrationBuilder.CreateIndex(
                name: "IX_ElevUtbildning_UtbildningarID",
                table: "ElevUtbildning",
                column: "UtbildningarID");

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
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Utbildningar");

            migrationBuilder.DropTable(
                name: "Kontaktuppgifter");
        }
    }
}
