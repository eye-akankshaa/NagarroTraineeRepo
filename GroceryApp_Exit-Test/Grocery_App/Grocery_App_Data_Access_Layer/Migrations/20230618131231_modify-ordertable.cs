using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocery_App_Data_Access_Layer.Migrations
{
    public partial class modifyordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityOfItems",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityOfItems",
                table: "Orders");
        }
    }
}
