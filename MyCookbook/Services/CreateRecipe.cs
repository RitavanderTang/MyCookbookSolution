using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCookbook.Data;
using MyCookbook.Models;

namespace MyCookbook.Services
{
    public class CreateRecipe
    {
        private void CreateRecipeFromButton()
        {

            var recipeCreateViewModel = new RecipeCreateViewModel();
            var recipe = new Recipe()
            {
                Id = recipeCreateViewModel.Id,
                Title = recipeCreateViewModel.Title
            };
        }
        
        
    }
}
