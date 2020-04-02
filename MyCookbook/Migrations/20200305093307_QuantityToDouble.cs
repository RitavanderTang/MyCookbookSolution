using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Migrations
{
    public partial class QuantityToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "RecipeItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 15 },
                column: "Quantity",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 16 },
                column: "Quantity",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 3 },
                column: "Quantity",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 4 },
                column: "Quantity",
                value: 20.0);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 5 },
                column: "Quantity",
                value: 150.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RecipeItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 15 },
                column: "Quantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 16 },
                column: "Quantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 3 },
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 4 },
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "RecipeItems",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 5 },
                column: "Quantity",
                value: 150);
        }
    }
}
