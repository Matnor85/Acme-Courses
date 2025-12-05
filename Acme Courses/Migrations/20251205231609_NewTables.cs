using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDatum",
                table: "Kurser",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "SlutDatum",
                table: "Kurser",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2025, 12, 15), new DateOnly(2025, 9, 1) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2025, 11, 30), new DateOnly(2025, 9, 1) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2025, 12, 1), new DateOnly(2025, 9, 1) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2025, 12, 20), new DateOnly(2025, 10, 1) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2026, 1, 15), new DateOnly(2025, 9, 15) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateOnly(2026, 2, 1), new DateOnly(2025, 11, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDatum",
                table: "Kurser",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SlutDatum",
                table: "Kurser",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "SlutDatum", "StartDatum" },
                values: new object[] { new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
