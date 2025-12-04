using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class addedseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kontaktuppgifter",
                columns: new[] { "ID", "ElevID", "KontaktInfo", "KontaktTyp" },
                values: new object[,]
                {
                    { 1, 1, "anna.andersson@example.com", "E-post" },
                    { 2, 2, "070-1111111", "Telefon" },
                    { 3, 3, "erik.eriksson@example.com", "E-post" },
                    { 4, 4, "070-2222222", "Telefon" },
                    { 5, 5, "lina.lind@example.com", "E-post" },
                    { 6, 6, "070-3333333", "Telefon" }
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

            migrationBuilder.InsertData(
                table: "Elever",
                columns: new[] { "ID", "Efternamn", "Förnamn", "KontaktUppgiftID", "UtbildningsID" },
                values: new object[,]
                {
                    { 1, "Andersson", "Anna", 1, 1 },
                    { 2, "Berg", "Björn", 2, 1 },
                    { 3, "Eriksson", "Erik", 3, 2 },
                    { 4, "Svensson", "Sara", 4, 2 },
                    { 5, "Lind", "Lina", 5, 3 },
                    { 6, "Olsson", "Oskar", 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
