using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreFoodProject.Migrations
{
    public partial class createDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FootId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootName = table.Column<string>(type: "varchar(50)", nullable: true),
                    FootShortDescription = table.Column<string>(type: "varchar(200)", nullable: true),
                    FootLongDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    FootPrice = table.Column<double>(type: "float", nullable: false),
                    FootImageURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FootThumbNailImageneURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FootStock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FootId);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
