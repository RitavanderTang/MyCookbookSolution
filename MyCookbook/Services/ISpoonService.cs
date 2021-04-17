using System.Net.Http;
using System.Threading.Tasks;

namespace MyCookbook.Services
{
    public interface ISpoonService
    {
        Task<HttpResponseMessage> GetRecipes(string cuisine);
    }
}