using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogy.DataAccessLayer.Migrations
{
    public partial class Appuser_rev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Writers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Writers_AppUserId",
                table: "Writers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Writers_AppUserId1",
                table: "Writers",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserId",
                table: "Writers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserId1",
                table: "Writers",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserId",
                table: "Writers");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserId1",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_AppUserId",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_AppUserId1",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Articles");
        }
    }
}
