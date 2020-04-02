using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyCookbook.Data
{
    public class RecipeItem
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }

        //public ICollection<Recipe> Recipes { get; set; }
        //public ICollection<RecipeIngredient> IngredientRecipes { get; set; }
    }
}