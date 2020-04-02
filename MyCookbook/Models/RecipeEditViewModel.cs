using Microsoft.AspNetCore.Mvc.Rendering;
using MyCookbook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class RecipeEditViewModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
     
        public string Instructions { get; set; }
        public string Unit { get; set; }
        public RecipeItem RecipeItem { get; set; }
        public Ingredient Ingredient { get; set; }
        public List<RecipeItem> RecipeItems { get; set; }
        public SelectList Units { get; set; }

        private ICollection<SelectListItem> _units; 
        public RecipeEditViewModel(ICollection<SelectListItem> units)
        {
            this._units = units;
            this.Units = new SelectList(this._units, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
            AddUnits(units);
        }

        public RecipeEditViewModel()
            : this(new List<SelectListItem>()) 
        {

        }

        internal void AddUnits(ICollection<SelectListItem> units)
        {
            this._units = units;
            this.Units = new SelectList(this._units, nameof(SelectListItem.Value), nameof(SelectListItem.Text), this.Unit);
        }
    }
}
