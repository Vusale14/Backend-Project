using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Project.Migrations
{
    public partial class CreateNewArrivalAndBestSellerAndFeaturedAndSpecialOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BestSellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Old_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    New_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestSellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Featureds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Old_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    New_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featureds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewArrivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Old_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    New_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewArrivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Old_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    New_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestSellers");

            migrationBuilder.DropTable(
                name: "Featureds");

            migrationBuilder.DropTable(
                name: "NewArrivals");

            migrationBuilder.DropTable(
                name: "SpecialOffers");
        }
    }
}
