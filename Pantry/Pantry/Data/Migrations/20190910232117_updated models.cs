using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Data.Migrations
{
    public partial class updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Category_CategoryId1",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_CategoryId1",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CategoryId",
                table: "Ingredient",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Category_CategoryId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_CategoryId",
                table: "Ingredient");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CategoryId1",
                table: "Ingredient",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Category_CategoryId1",
                table: "Ingredient",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
