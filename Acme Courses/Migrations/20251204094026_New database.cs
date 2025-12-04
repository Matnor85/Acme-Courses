using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class Newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_UtbildningID",
                table: "Kurser",
                column: "UtbildningID");

            migrationBuilder.CreateIndex(
                name: "IX_ElevUtbildning_UtbildningarID",
                table: "ElevUtbildning",
                column: "UtbildningarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Utbildningar_UtbildningID",
                table: "Kurser",
                column: "UtbildningID",
                principalTable: "Utbildningar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Utbildningar_UtbildningID",
                table: "Kurser");

            migrationBuilder.DropTable(
                name: "ElevUtbildning");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_UtbildningID",
                table: "Kurser");
        }
    }
}
