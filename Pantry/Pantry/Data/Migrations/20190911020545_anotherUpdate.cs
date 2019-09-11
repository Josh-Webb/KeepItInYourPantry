using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Data.Migrations
{
    public partial class anotherUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupedCategoriesCatId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryViewModelCategoryId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryViewModel",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryViewModel", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "GroupedCategories",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    IngredientCount = table.Column<int>(nullable: false),
                    CategoryViewModelCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupedCategories", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_GroupedCategories_CategoryViewModel_CategoryViewModelCategoryId",
                        column: x => x.CategoryViewModelCategoryId,
                        principalTable: "CategoryViewModel",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_GroupedCategoriesCatId",
                table: "Ingredient",
                column: "GroupedCategoriesCatId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryViewModelCategoryId",
                table: "Category",
                column: "CategoryViewModelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupedCategories_CategoryViewModelCategoryId",
                table: "GroupedCategories",
                column: "CategoryViewModelCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryViewModel_CategoryViewModelCategoryId",
                table: "Category",
                column: "CategoryViewModelCategoryId",
                principalTable: "CategoryViewModel",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_GroupedCategories_GroupedCategoriesCatId",
                table: "Ingredient",
                column: "GroupedCategoriesCatId",
                principalTable: "GroupedCategories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryViewModel_CategoryViewModelCategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_GroupedCategories_GroupedCategoriesCatId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "GroupedCategories");

            migrationBuilder.DropTable(
                name: "CategoryViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_GroupedCategoriesCatId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryViewModelCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "GroupedCategoriesCatId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CategoryViewModelCategoryId",
                table: "Category");
        }
    }
}
