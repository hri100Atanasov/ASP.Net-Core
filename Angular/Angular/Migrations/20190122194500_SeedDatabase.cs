using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Audi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mercedes')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('E46', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('A8', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('S500', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
