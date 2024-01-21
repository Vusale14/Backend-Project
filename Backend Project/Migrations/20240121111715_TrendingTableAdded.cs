using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Project.Migrations
{
    public partial class TrendingTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "New_Price",
                table: "Trendings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Offer",
                table: "Trendings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Old_Price",
                table: "Trendings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trendings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "New_Price",
                table: "Trendings");

            migrationBuilder.DropColumn(
                name: "Offer",
                table: "Trendings");

            migrationBuilder.DropColumn(
                name: "Old_Price",
                table: "Trendings");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trendings");
        }
    }
}
