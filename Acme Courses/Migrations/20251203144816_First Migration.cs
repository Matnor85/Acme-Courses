using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    UtbildningsID = table.Column<int>(type: "int", nullable: false),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktUppgiftID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.ID);
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

            migrationBuilder.InsertData(
                table: "Utbildningar",
                columns: new[] { "ID", "Beskrivning", "Namn" },
                values: new object[,]
                {
                    { 1, "Backend-Utvecklare", "BUV25" },
                    { 2, "Frontend-Utvecklare", "FUV25" },
                    { 3, "Fullstack-Utvecklare", "FSUV25" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Kontaktuppgifter");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Utbildningar");
        }
    }
}
