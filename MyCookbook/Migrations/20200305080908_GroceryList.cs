using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Migrations
{
    public partial class GroceryList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailsViewModelId",
                table: "RecipeItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCreateViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCreateViewModel_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetailsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDetailsViewModel_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_RecipeDetailsViewModelId",
                table: "RecipeItems",
                column: "RecipeDetailsViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCreateViewModel_RecipeId",
                table: "RecipeCreateViewModel",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetailsViewModel_IngredientId",
                table: "RecipeDetailsViewModel",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_RecipeDetailsViewModel_RecipeDetailsViewModelId",
                table: "RecipeItems",
                column: "RecipeDetailsViewModelId",
                principalTable: "RecipeDetailsViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_RecipeDetailsViewModel_RecipeDetailsViewModelId",
                table: "RecipeItems");

            migrationBuilder.DropTable(
                name: "RecipeCreateViewModel");

            migrationBuilder.DropTable(
                name: "RecipeDetailsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItems_RecipeDetailsViewModelId",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "RecipeDetailsViewModelId",
                table: "RecipeItems");
        }
    }
}
