using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocery_App_Data_Access_Layer.Migrations
{
    public partial class addedimagecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Products");
        }
    }
}
