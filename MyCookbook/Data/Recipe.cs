using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }

        public List<RecipeItem> RecipeItems { get; set; }
        //public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Recipe()
        {
            //RecipeIngredients = new List<RecipeIngredient>();
            RecipeItems = new List<RecipeItem>();        
        }

    
    }
}
