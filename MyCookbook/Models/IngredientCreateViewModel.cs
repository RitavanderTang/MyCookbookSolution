using Microsoft.AspNetCore.Mvc.Rendering;
using MyCookbook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Models
{
    public class IngredientCreateViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ingredient")]
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public List<RecipeItem> AddedRecipeItems { get; set; }
        public Ingredient Ingredient { get; set; }
        public RecipeItem  RecipeItem { get; set; }

        // Hier Enum definieren van Units voor SelectList
        //[NotMapped]
        public SelectList Units { get; set; }

        private ICollection<SelectListItem> _units;  // Zo blijft de collectie ook aanspreekbaar na het construeren van IngredientCreateViewModel, levensduur verlengt, scope vergroot. Niet alleen binnen constructer, maar ook buiten de constructor kan je erbij.

        public IngredientCreateViewModel(ICollection<SelectListItem> units)
        {
            this._units = units;
            this.Units = new SelectList(this._units, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
            AddUnits(units);

       
        }

        public IngredientCreateViewModel()
            : this(new List<SelectListItem>()) // this verwijst naar bovenstaande constructor. Die wordt dus eerst uitgevoerd bij het aandroepen van deze constructor --> Constructor Chaining
        {

        }

        internal void AddUnits(ICollection<SelectListItem> units)
        {

            this._units = units;
            this.Units = new SelectList(this._units, nameof(SelectListItem.Value), nameof(SelectListItem.Text), this.Unit);
        }

    }
}
