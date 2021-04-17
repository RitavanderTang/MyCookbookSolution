using System.Net.Http;
using System.Threading.Tasks;

namespace MyCookbook.Clients
{
    public interface ISpoonClient
    {
        Task<HttpResponseMessage> GetRecipes(string cuisine);
    }
}