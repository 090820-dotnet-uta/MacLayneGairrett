using Microsoft.EntityFrameworkCore.Migrations;

namespace RPS_Game_Refactored.Migrations
{
    public partial class _6thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rounds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
