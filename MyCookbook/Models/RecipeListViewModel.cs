using MyCookbook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class RecipeListViewModel
    {
        public int Id { get; set; }
        [DisplayName("My Recipes:")]
        public string Title { get; set; }
        public string Instructions { get; set; }

        public ICollection<RecipeItem> Ingredients { get; set; }
    }
}
