using Newtonsoft.Json;
using Pegler.Leaderboard.BusinessLogic.Contracts;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pegler.Leaderboard.BusinessLogic.Managers
{
    public class HttpClientManager : IHttpClientManager
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientManager(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<(T, string)> DeleteAsync<T>(string path)
        {
            try
            {
                using (HttpClient httpClient = GetHttpClientAsync())
                {
                    HttpResponseMessage deleteResponse = await httpClient.DeleteAsync(path);

                    string responseContent = await deleteResponse.Content.ReadAsStringAsync();

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        return (JsonConvert.DeserializeObject<T>(responseContent), null);
                    }
                    else
                    {
                        Log.Information($"DELETE - StatusCode: {deleteResponse.StatusCode} | Response: {responseContent}");

                        return (default, $"DELETE request was unsuccessful.");
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ForContext("Type", "Error")
                   .ForContext("Exception", exception)
                   .Error(exception, exception.Message);

                return (default, $"DELETE - An exception has occured: {exception.Message}");
            }
        }

        public async Task<(T, string)> GetAsync<T>(string path)
        {
            try
            {
                using (HttpClient httpClient = GetHttpClientAsync())
                {
                    HttpResponseMessage getResponse = await httpClient.GetAsync(path);

                    string responseContent = await getResponse.Content.ReadAsStringAsync();

                    if (getResponse.IsSuccessStatusCode)
                    {
                        return (JsonConvert.DeserializeObject<T>(responseContent), null);
                    }
                    else
                    {
                        Log.Information($"GET - StatusCode: {getResponse.StatusCode} | Response: {responseContent}");

                        return (default, $"GET request was unsuccessful.");
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ForContext("Type", "Error")
                   .ForContext("Exception", exception)
                   .Error(exception, exception.Message);

                return (default, $"GET - An exception has occured: {exception.Message}");
            }
        }

        public async Task<(T, string)> PostAsync<T>(string path, StringContent stringContent)
        {
            try
            {
                using (HttpClient httpClient = GetHttpClientAsync())
                {
                    HttpResponseMessage postResponse = await httpClient.PostAsync(path, stringContent);

                    string responseContent = await postResponse.Content.ReadAsStringAsync();

                    if (postResponse.IsSuccessStatusCode)
                    {
                        return (JsonConvert.DeserializeObject<T>(responseContent), null);
                    }
                    else
                    {
                        Log.Information($"POST - StatusCode: {postResponse.StatusCode} | Response: {responseContent}");

                        return (default, $"POST request was unsuccessful.");
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ForContext("Type", "Error")
                   .ForContext("Exception", exception)
                   .Error(exception, exception.Message);

                return (default, $"POST - An exception has occured: {exception.Message}");
            }
        }

        public async Task<(T, string)> PutAsync<T>(string path, StringContent stringContent)
        {
            try
            {
                using (HttpClient httpClient = GetHttpClientAsync())
                {
                    HttpResponseMessage putResponse = await httpClient.PutAsync(path, stringContent);

                    string responseContent = await putResponse.Content.ReadAsStringAsync();

                    if (putResponse.IsSuccessStatusCode)
                    {
                        return (JsonConvert.DeserializeObject<T>(responseContent), null);
                    }
                    else
                    {
                        Log.Information($"PUT - StatusCode: {putResponse.StatusCode} | Response: {responseContent}");

                        return (default, $"PUT request was unsuccessful.");
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ForContext("Type", "Error")
                   .ForContext("Exception", exception)
                   .Error(exception, exception.Message);

                return (default, $"PUT - An exception has occured: {exception.Message}");
            }
        }

        private HttpClient GetHttpClientAsync()
        {
            return httpClientFactory.CreateClient("default");
        }
    }
}
