using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Data.Migrations
{
    public partial class SepThirty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeDetailsView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ReadyInMinutes = table.Column<int>(nullable: false),
                    Servings = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImageType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetailsView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeForListModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpoonacularId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ImageType = table.Column<string>(nullable: true),
                    UsedIngredientCount = table.Column<int>(nullable: false),
                    MissedIngredientCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeForListModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalyzedInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeDetailsViewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyzedInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyzedInstructions_RecipeDetailsView_RecipeDetailsViewId",
                        column: x => x.RecipeDetailsViewId,
                        principalTable: "RecipeDetailsView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtendedIngredientsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    OriginalString = table.Column<string>(nullable: true),
                    RecipeDetailsViewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedIngredientsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtendedIngredientsViewModel_RecipeDetailsView_RecipeDetailsViewId",
                        column: x => x.RecipeDetailsViewId,
                        principalTable: "RecipeDetailsView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StepsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Step = table.Column<string>(nullable: true),
                    AnalyzedInstructionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepsViewModel_AnalyzedInstructions_AnalyzedInstructionsId",
                        column: x => x.AnalyzedInstructionsId,
                        principalTable: "AnalyzedInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyzedInstructions_RecipeDetailsViewId",
                table: "AnalyzedInstructions",
                column: "RecipeDetailsViewId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedIngredientsViewModel_RecipeDetailsViewId",
                table: "ExtendedIngredientsViewModel",
                column: "RecipeDetailsViewId");

            migrationBuilder.CreateIndex(
                name: "IX_StepsViewModel_AnalyzedInstructionsId",
                table: "StepsViewModel",
                column: "AnalyzedInstructionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtendedIngredientsViewModel");

            migrationBuilder.DropTable(
                name: "RecipeForListModel");

            migrationBuilder.DropTable(
                name: "StepsViewModel");

            migrationBuilder.DropTable(
                name: "AnalyzedInstructions");

            migrationBuilder.DropTable(
                name: "RecipeDetailsView");
        }
    }
}
