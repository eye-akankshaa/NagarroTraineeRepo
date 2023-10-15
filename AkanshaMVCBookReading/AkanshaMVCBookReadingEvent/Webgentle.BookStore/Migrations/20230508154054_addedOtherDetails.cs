using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.BookStore.Migrations
{
    public partial class addedOtherDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherDetails",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherDetails",
                table: "Events");
        }
    }
}
