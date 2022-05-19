using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menuu.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description) " +
                "VALUES('Regular','Snack made with regular ingredients')");

            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description) " +
                "VALUES('Vegan','Snack made with vegan ingredients')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
