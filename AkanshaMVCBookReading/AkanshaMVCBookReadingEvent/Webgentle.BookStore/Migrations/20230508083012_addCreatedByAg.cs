using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.BookStore.Migrations
{
    public partial class addCreatedByAg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");
        }
    }
}
