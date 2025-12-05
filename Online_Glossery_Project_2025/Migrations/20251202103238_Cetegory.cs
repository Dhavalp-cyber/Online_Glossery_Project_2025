using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Glossery_Project_2025.Migrations
{
    /// <inheritdoc />
    public partial class Cetegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cetegories",
                columns: table => new
                {
                    CetegoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CetegoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cetegories", x => x.CetegoryID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    CetegoryID = table.Column<int>(type: "int", nullable: false),
                    SubCetegoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subCetegories",
                columns: table => new
                {
                    SubCetegoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCetegoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CetegoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCetegories", x => x.SubCetegoryID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cetegories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "subCetegories");
        }
    }
}
