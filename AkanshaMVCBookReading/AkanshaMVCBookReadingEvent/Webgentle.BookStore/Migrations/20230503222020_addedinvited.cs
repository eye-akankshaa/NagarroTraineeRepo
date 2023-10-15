using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.BookStore.Migrations
{
    public partial class addedinvited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "invitedTo",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invitedTo",
                table: "Events");
        }
    }
}
