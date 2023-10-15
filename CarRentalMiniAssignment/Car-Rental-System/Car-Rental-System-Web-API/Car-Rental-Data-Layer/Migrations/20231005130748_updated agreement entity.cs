using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Rental_Data_Layer.Migrations
{
    public partial class updatedagreemententity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    AgreementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalDuration = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isReturnRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreement", x => x.AgreementID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPrice = table.Column<long>(type: "bigint", nullable: false),
                    AvailabilityStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "VehicleId", "AvailabilityStatus", "Maker", "Model", "RentalPrice" },
                values: new object[,]
                {
                    { 1, true, "Hyundai", "I-20", 2000L },
                    { 2, true, "Hyundai", "Verna", 3000L },
                    { 3, true, "Maruti Suzuki", "Dezire", 2000L },
                    { 4, true, "Tata", "Nexon", 4000L },
                    { 5, true, "Tata", "Altroz", 2000L }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Name", "Password", "Phone", "isAdmin" },
                values: new object[,]
                {
                    { 1, "admin1@gmail.com", "Admin1", "admin1@111", 2345678909L, true },
                    { 2, "admin2@gmail.com", "Admin2", "admin2@222", 1234567896L, true },
                    { 3, "akansha@gmail.com", "Akansha", "akansha@3198", 1234567896L, false },
                    { 4, "shubhi@gmail.com", "Shubhi", "shubhi@0868", 1234567896L, false },
                    { 5, "abha@gmail.com", "Abha", "abha@0868", 1234567896L, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
