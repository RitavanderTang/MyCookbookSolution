using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCookbook.Data;
using MyCookbook.Models;

namespace MyCookbook.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var vm = new PagedViewModel<RecipeListViewModel>();

            if (pageNumber.HasValue)
            {
                vm.PageNumber = pageNumber.Value;
            }
            vm.Items = await _context.Recipes
                .Skip((vm.PageNumber - 1) * vm.PageSize)
                .Take(vm.PageSize)
                .Select(
                r => new RecipeListViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Instructions = r.Instructions }).ToListAsync();
            vm.ItemCount = await _context.Recipes.CountAsync();
            return View(vm);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _context.Recipes.Select(r => new RecipeDetailsViewModel
            {
                Id = r.Id,
                Title = r.Title,
                Instructions = r.Instructions,
                RecipeItems = _context.RecipeItems
                .Where(ri => ri.RecipeId == id)
                .Select(i => new RecipeItem
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Unit = i.Unit
                }).ToList()
            }).FirstOrDefaultAsync(m => m.Id == id);

            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // https://www.pluralsight.com/guides/asp-net-mvc-using-multiple-submit-buttons-with-default-model-binding-and-controller-actions
        public async Task<IActionResult> addRecipe([Bind("Id,Title,Instructions")]RecipeCreateViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipe = new Recipe()
                {
                    Id = recipeViewModel.Id,
                    Title = recipeViewModel.Title,
                    Instructions = recipeViewModel.Instructions
                };
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(addIngredient), new { RecipeId = recipe.Id });
            }
            return View(nameof(Create));
        }

        public async Task<IActionResult> addIngredient(int RecipeId)
        {
            var vm = new IngredientCreateViewModel(await _context.RecipeItems
                .Select(r => new SelectListItem
                {
                    Value = r.Unit,
                    Text = r.Unit
                }).Distinct().ToListAsync());

            return View(vm);
        }

        [HttpPost, Route("Recipes/addIngredient/{RecipeId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addIngredient(IngredientCreateViewModel ingredientViewModel, [FromRoute] int RecipeId)
        {
            //var addedRecipeItems = new List<RecipeItem>();

            if (ModelState.IsValid)
            {
                var ingredient = new Ingredient();
                var recipeItem = new RecipeItem();

                var ingredientExist = _context.Ingredients.Where(x => x.Name == ingredientViewModel.Name).Select(x => x.Name).FirstOrDefault();

                if (ingredientExist == null)
                {
                    ingredient.Name = ingredientViewModel.Name;
                    _context.Add(ingredient);
                    recipeItem.Name = ingredientViewModel.Name;
                    recipeItem.Ingredient = ingredient;
                }
                else
                {
                    var ingredientId = _context.Ingredients.Where(x => x.Name == ingredientViewModel.Name).Select(x => x.Id).First();
                    recipeItem.IngredientId = ingredientId;
                    recipeItem.Name = ingredientViewModel.Name;   
                }

                recipeItem.Quantity = ingredientViewModel.Quantity;
                recipeItem.Unit = ingredientViewModel.Unit;
                recipeItem.RecipeId = RecipeId;

                //ingredientViewModel.AddedRecipeItems = addedRecipeItems;
                //addedRecipeItems.Add(recipeItem);

                _context.Add(recipeItem);
                await _context.SaveChangesAsync();
                ModelState.Clear();
            }
 
            ingredientViewModel.AddUnits(await _context.RecipeItems
                .Select(p => new SelectListItem
                {
                    Value = p.Unit,
                    Text = p.Unit
                }).ToListAsync());

            return RedirectToAction(nameof(addIngredient), new { RecipeId = RecipeId});
        }

        // GET: Recipes/Create
        public IActionResult Create()
        { 
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(IngredientCreateViewModel ingredientVieModel)
        {
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GroceryListCreate()
        {
            var vm = new RecipeCreateViewModel();

            vm.Recipes = await _context.Recipes.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Title,
                Selected = false
            }).ToListAsync();
            return View(vm); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GroceryListCreate(RecipeCreateViewModel recipeViewModel)
        {
            var RecipeList = new List<Recipe>();

            foreach (var recipe in recipeViewModel.Recipes)
            {
                if (recipe.Selected)
                {
                    var recipeId = int.Parse(recipe.Value);
 
                    RecipeList.Add(_context.Recipes.FirstOrDefault(p => p.Id == recipeId));
                }
            }
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GroceryListDetails), new { recipeList = RecipeList });
        }

        public IActionResult GroceryListDetails(List<Recipe> recipeList)
        {
            //var recipeItems = new RecipeItem();
            
            foreach (var recipe in recipeList)
            {
                var recipeItems = _context.RecipeItems
                    .Where(ri => ri.RecipeId == recipe.Id)
                    .Select(i => new RecipeItem 
                    { 
                        Name = i.Name, 
                        Quantity = i.Quantity, 
                        Unit = i.Unit 
                    });
                // In recipeItems nu alle RecipeItems van de geselecteerde recepten
            }
            // Hier de RecipeItems bij elkaar optellen en dan laten zien
            //GroceryListDetailsView maken met opgetelde recipeitems.


            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = new Ingredient();

            var vm = await _context.Recipes.Select(r => new RecipeEditViewModel
            {
                RecipeId = r.Id,
                Title = r.Title,
                Instructions = r.Instructions,

                RecipeItems = _context.RecipeItems
                .Where(ri => ri.RecipeId == id)
                .Select(i => new RecipeItem
                {
                    IngredientId = i.IngredientId,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Unit = i.Unit
                }).ToList()
            }).FirstOrDefaultAsync(m => m.RecipeId == id);

            vm.AddUnits(await _context.RecipeItems
                .Select(p => new SelectListItem
                {
                    Value = p.Unit,
                    Text = p.Unit
                }).Distinct().ToListAsync());
            
            return View(vm);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Title,Instructions,RecipeItem,RecipeItems")] RecipeEditViewModel recipeEditViewModel)
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Title,Instructions,RecipeItem,RecipeItems")] RecipeEditViewModel recipeEditViewModel)
        {
            
            if (id != recipeEditViewModel.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var recipe = _context.Recipes.Find(id);
                    recipe.Title = recipeEditViewModel.Title;
                    recipe.Instructions = recipeEditViewModel.Instructions;

                    //Explicit loading voor RecipeItems https://entityframeworkcore.com/querying-data-loading-eager-lazy
                    // Dan met loop door properties recipeitem heen om te kijken of ze zijn aangepast of niet. 

                    _context.Entry(recipe)
                        .Collection(c => c.RecipeItems)
                        .Load();

                    for (int i = 0; i < recipe.RecipeItems.Count; i++)
                    {
                        recipe.RecipeItems[i].Name = recipeEditViewModel.RecipeItems[i].Name;
                        recipe.RecipeItems[i].Quantity = recipeEditViewModel.RecipeItems[i].Quantity;
                        recipe.RecipeItems[i].Unit = recipeEditViewModel.RecipeItems[i].Unit;
                    }           
                    
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipeEditViewModel.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipeEditViewModel);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditDelete(int id)
        //{
        //    var recipe = await _context.Recipes.FindAsync(id);
        //    _context.Recipes.Remove(recipe);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
