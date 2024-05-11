using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogy.DataAccessLayer.Migrations
{
    public partial class Appuuser_writer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Writers_AppUserID",
                table: "Writers",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserID",
                table: "Writers",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writers_AspNetUsers_AppUserID",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_AppUserID",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Writers");
        }
    }
}
