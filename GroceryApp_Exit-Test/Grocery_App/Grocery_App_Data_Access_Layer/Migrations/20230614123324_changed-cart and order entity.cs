using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocery_App_Data_Access_Layer.Migrations
{
    public partial class changedcartandorderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductEntityProductId",
                table: "Orders",
                column: "ProductEntityProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductEntityProductId",
                table: "Orders",
                column: "ProductEntityProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductEntityProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductEntityProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductEntityProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
