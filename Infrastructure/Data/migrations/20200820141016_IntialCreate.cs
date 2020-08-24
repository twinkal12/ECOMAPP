using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productBrands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Desc = table.Column<string>(maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pictureurl = table.Column<string>(nullable: false),
                    ProducTypeId = table.Column<int>(nullable: false),
                    ProductBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_productsType_ProducTypeId",
                        column: x => x.ProducTypeId,
                        principalTable: "productsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "productBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ProducTypeId",
                table: "products",
                column: "ProducTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductBrandId",
                table: "products",
                column: "ProductBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "productsType");

            migrationBuilder.DropTable(
                name: "productBrands");
        }
    }
}
