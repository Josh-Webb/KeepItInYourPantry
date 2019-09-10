using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CategoryId1",
                table: "Ingredient",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_UserId",
                table: "Ingredient",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Category_CategoryId1",
                table: "Ingredient",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_AspNetUsers_UserId",
                table: "Ingredient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Category_CategoryId1",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_AspNetUsers_UserId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_CategoryId1",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_UserId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
