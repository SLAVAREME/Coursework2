using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework2.Migrations
{
    public partial class ww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_session_Leading_IdLeading",
                table: "Game_session");

            migrationBuilder.DropIndex(
                name: "IX_Game_session_IdLeading",
                table: "Game_session");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_session_IdLeading",
                table: "Game_session",
                column: "IdLeading");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_session_Leading_IdLeading",
                table: "Game_session",
                column: "IdLeading",
                principalTable: "Leading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
