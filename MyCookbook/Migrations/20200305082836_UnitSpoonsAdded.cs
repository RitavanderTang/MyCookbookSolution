using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Migrations
{
    public partial class UnitSpoonsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Salt" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Olive Oil" });

            migrationBuilder.InsertData(
                table: "RecipeItems",
                columns: new[] { "RecipeId", "IngredientId", "Name", "Quantity", "RecipeDetailsViewModelId", "Unit" },
                values: new object[] { 1, 16, "Salt", 500, null, "Teaspoon" });

            migrationBuilder.InsertData(
                table: "RecipeItems",
                columns: new[] { "RecipeId", "IngredientId", "Name", "Quantity", "RecipeDetailsViewModelId", "Unit" },
                values: new object[] { 1, 15, "Olive Oil", 500, null, "Tablespoon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
