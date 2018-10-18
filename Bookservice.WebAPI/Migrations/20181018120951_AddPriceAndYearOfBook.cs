using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookservice.WebAPI.Migrations
{
    public partial class AddPriceAndYearOfBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Book",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Year" },
                values: new object[] { 5.99m, 2010 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Year" },
                values: new object[] { 6.99m, 2011 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Year" },
                values: new object[] { 3.99m, 2009 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "Year" },
                values: new object[] { 7.99m, 2010 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "Year" },
                values: new object[] { 9.99m, 2015 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "Year" },
                values: new object[] { 7.99m, 2010 });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "Year" },
                values: new object[] { 10.99m, 2018 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Book");
        }
    }
}
