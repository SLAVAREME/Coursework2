using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework2.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Session_Users_UsersId",
                table: "Client_Session");

            migrationBuilder.DropIndex(
                name: "IX_Client_Session_UsersId",
                table: "Client_Session");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Client_Session");

            migrationBuilder.CreateIndex(
                name: "IX_Game_session_IdLeading",
                table: "Game_session",
                column: "IdLeading");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Session_Id_User",
                table: "Client_Session",
                column: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Session_Users_Id_User",
                table: "Client_Session",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_session_Leading_IdLeading",
                table: "Game_session",
                column: "IdLeading",
                principalTable: "Leading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Session_Users_Id_User",
                table: "Client_Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_session_Leading_IdLeading",
                table: "Game_session");

            migrationBuilder.DropIndex(
                name: "IX_Game_session_IdLeading",
                table: "Game_session");

            migrationBuilder.DropIndex(
                name: "IX_Client_Session_Id_User",
                table: "Client_Session");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Client_Session",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_Session_UsersId",
                table: "Client_Session",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Session_Users_UsersId",
                table: "Client_Session",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
