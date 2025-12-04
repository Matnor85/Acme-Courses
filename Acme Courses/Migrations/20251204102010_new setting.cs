uusing Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class newsetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elever_Kontaktuppgifter_KontaktUppgiftID",
                table: "Elever");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontaktuppgifter",
                table: "Kontaktuppgifter");

            migrationBuilder.RenameTable(
                name: "Kontaktuppgifter",
                newName: "Kontaktuppgift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontaktuppgift",
                table: "Kontaktuppgift",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elever_Kontaktuppgift_KontaktUppgiftID",
                table: "Elever",
                column: "KontaktUppgiftID",
                principalTable: "Kontaktuppgift",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elever_Kontaktuppgift_KontaktUppgiftID",
                table: "Elever");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontaktuppgift",
                table: "Kontaktuppgift");

            migrationBuilder.RenameTable(
                name: "Kontaktuppgift",
                newName: "Kontaktuppgifter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontaktuppgifter",
                table: "Kontaktuppgifter",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elever_Kontaktuppgifter_KontaktUppgiftID",
                table: "Elever",
                column: "KontaktUppgiftID",
                principalTable: "Kontaktuppgifter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
