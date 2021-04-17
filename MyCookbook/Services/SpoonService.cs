using MyCookbook.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCookbook.Services
{
    public class SpoonService : ISpoonService
    {
        private readonly ISpoonClient _spoonClient;
        public SpoonService(ISpoonClient spoonClient)
        {
            _spoonClient = spoonClient ?? throw new ArgumentNullException(nameof(spoonClient));
        }
        public async Task<HttpResponseMessage> GetRecipes(string cuisine)
        {
            return await _spoonClient.GetRecipes(cuisine);
        }
    }
}
