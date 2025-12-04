using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class PerfectedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KontaktUppgiftID",
                table: "Elever");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KontaktUppgiftID",
                table: "Elever",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 1,
                column: "KontaktUppgiftID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 2,
                column: "KontaktUppgiftID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 3,
                column: "KontaktUppgiftID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 4,
                column: "KontaktUppgiftID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 5,
                column: "KontaktUppgiftID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Elever",
                keyColumn: "ID",
                keyValue: 6,
                column: "KontaktUppgiftID",
                value: 0);
        }
    }
}
