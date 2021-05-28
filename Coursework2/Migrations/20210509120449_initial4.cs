using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework2.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_package_questions",
                table: "Game_session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PackageOfQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageEditor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOfQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPackage = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_PackageOfQuestions_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "PackageOfQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_session_Id_package_questions",
                table: "Game_session",
                column: "Id_package_questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdPackage",
                table: "Questions",
                column: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_session_PackageOfQuestions_Id_package_questions",
                table: "Game_session",
                column: "Id_package_questions",
                principalTable: "PackageOfQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_session_PackageOfQuestions_Id_package_questions",
                table: "Game_session");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "PackageOfQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Game_session_Id_package_questions",
                table: "Game_session");

            migrationBuilder.DropColumn(
                name: "Id_package_questions",
                table: "Game_session");
        }
    }
}
