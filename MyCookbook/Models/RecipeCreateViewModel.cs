using Microsoft.AspNetCore.Mvc.Rendering;
using MyCookbook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class RecipeCreateViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public Recipe Recipe { get; set; }
        [NotMapped]
        public List<SelectListItem> Recipes { get; set; }


    }
}
