using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreFoodProject.Migrations
{
    public partial class updateFooClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FootShortDescription",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FootThumbNailImageneURL",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "FootLongDescription",
                table: "Foods",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Foods",
                newName: "FootLongDescription");

            migrationBuilder.AddColumn<string>(
                name: "FootShortDescription",
                table: "Foods",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FootThumbNailImageneURL",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
