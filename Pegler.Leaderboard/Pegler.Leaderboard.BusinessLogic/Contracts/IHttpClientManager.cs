using System.Net.Http;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.BusinessLogic.Contracts
{
    public interface IHttpClientManager
    {
        Task<(T, string)> DeleteAsync<T>(string path);

        Task<(T, string)> GetAsync<T>(string path);

        Task<(T, string)> PostAsync<T>(string path, StringContent stringContent);

        Task<(T, string)> PutAsync<T>(string path, StringContent stringContent);
    }
}
