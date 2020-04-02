using Microsoft.AspNetCore.Mvc.Rendering;
using MyCookbook.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyCookbook.Models
{
    public class RecipeDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public Ingredient Ingredient { get; set; }

        [DisplayName("Ingredients")]
        public ICollection<RecipeItem> RecipeItems { get; set; }

        
    }
}