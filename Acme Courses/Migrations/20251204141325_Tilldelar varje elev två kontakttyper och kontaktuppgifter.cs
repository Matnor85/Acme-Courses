using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class Tilldelarvarjeelevtvåkontakttyperochkontaktuppgifter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 2,
                column: "ElevID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ElevID", "KontaktInfo" },
                values: new object[] { 2, "bjorn.berg@example.com" });

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 4,
                column: "ElevID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ElevID", "KontaktInfo" },
                values: new object[] { 3, "erik.eriksson@example.com" });

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 6,
                column: "ElevID",
                value: 3);

            migrationBuilder.InsertData(
                table: "Kontaktuppgifter",
                columns: new[] { "ID", "ElevID", "KontaktInfo", "KontaktTyp" },
                values: new object[,]
                {
                    { 7, 4, "sara.svensson@example.com", "E-post" },
                    { 8, 4, "070-4444444", "Telefon" },
                    { 9, 5, "lina.lind@example.com", "E-post" },
                    { 10, 5, "070-5555555", "Telefon" },
                    { 11, 6, "oskar.olsson@example.com", "E-post" },
                    { 12, 6, "070-6666666", "Telefon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 2,
                column: "ElevID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ElevID", "KontaktInfo" },
                values: new object[] { 3, "erik.eriksson@example.com" });

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 4,
                column: "ElevID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ElevID", "KontaktInfo" },
                values: new object[] { 5, "lina.lind@example.com" });

            migrationBuilder.UpdateData(
                table: "Kontaktuppgifter",
                keyColumn: "ID",
                keyValue: 6,
                column: "ElevID",
                value: 6);
        }
    }
}
