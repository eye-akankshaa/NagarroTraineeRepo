using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.BookStore.Migrations
{
    public partial class addedeventypecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eventType",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventType",
                table: "Events");
        }
    }
}
