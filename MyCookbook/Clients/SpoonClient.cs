using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCookbook.Clients
{
    public class SpoonClient : ISpoonClient
    {
        private readonly HttpClient _client;

        public SpoonClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
        }

        public async Task<HttpResponseMessage> GetRecipes(string cuisine)
        {
            var apiToken = "a888ac682b0548efb1ff187ae30d692e";
            return await _client.GetAsync($"recipes/complexSearch?apiKey={apiToken}&cuisine={cuisine}");
        }
    }
}
