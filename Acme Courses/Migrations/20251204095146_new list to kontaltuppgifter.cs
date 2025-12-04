using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme_Courses.Migrations
{
    /// <inheritdoc />
    public partial class newlisttokontaltuppgifter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Elever_KontaktUppgiftID",
                table: "Elever",
                column: "KontaktUppgiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elever_Kontaktuppgifter_KontaktUppgiftID",
                table: "Elever",
                column: "KontaktUppgiftID",
                principalTable: "Kontaktuppgifter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elever_Kontaktuppgifter_KontaktUppgiftID",
                table: "Elever");

            migrationBuilder.DropIndex(
                name: "IX_Elever_KontaktUppgiftID",
                table: "Elever");
        }
    }
}
