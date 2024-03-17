using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogy.DataAccessLayer.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImageUrl",
                table: "Categories");
        }
    }
}
