using Microsoft.AspNetCore.Mvc;
using MyCookbook.Clients;
using MyCookbook.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCookbook.Controllers
{
    public class SpoonController : Controller
    {
        private readonly ISpoonService _spoonService;
        public SpoonController(ISpoonService spoonService)
        {
            _spoonService = spoonService ?? throw new ArgumentNullException(nameof(spoonService));
        }
        [HttpGet, Route("Spoon/{cuisine}")]
        public async Task<ActionResult> GetRecipesCuisine(string cuisine)
        {
            var result = await _spoonService.GetRecipes(cuisine);

            return Ok(result);
        }
    }
}
