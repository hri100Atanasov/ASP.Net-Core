using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Categories(CategoryName) VALUES ('Fruit pies')");
            migrationBuilder.Sql("INSERT INTO dbo.Categories(CategoryName) VALUES ('Cheese cakes')");
            migrationBuilder.Sql("INSERT INTO dbo.Categories(CategoryName) VALUES ('Seasonal pies')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
