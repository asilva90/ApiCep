using Refit;
using System.Threading.Tasks;

namespace ApiTest
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAdressAsync(string cep);
    }
}
