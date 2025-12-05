using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class Lagttillkursledare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KursledareID",
                table: "Kurser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kursledare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursledare", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 1,
                column: "KursledareID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 2,
                column: "KursledareID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 3,
                column: "KursledareID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 4,
                column: "KursledareID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 5,
                column: "KursledareID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Kurser",
                keyColumn: "ID",
                keyValue: 6,
                column: "KursledareID",
                value: 3);

            migrationBuilder.InsertData(
                table: "Kursledare",
                columns: new[] { "ID", "Efternamn", "Förnamn" },
                values: new object[,]
                {
                    { 1, "Karlsson", "Karin" },
                    { 2, "Larsson", "Lars" },
                    { 3, "Marklund", "Mia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_KursledareID",
                table: "Kurser",
                column: "KursledareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Kursledare_KursledareID",
                table: "Kurser",
                column: "KursledareID",
                principalTable: "Kursledare",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Kursledare_KursledareID",
                table: "Kurser");

            migrationBuilder.DropTable(
                name: "Kursledare");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_KursledareID",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "KursledareID",
                table: "Kurser");
        }
    }
}
