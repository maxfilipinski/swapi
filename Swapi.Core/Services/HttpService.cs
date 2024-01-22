using Microsoft.Extensions.Logging;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;
using System.Text.Json;

namespace Swapi.Core.Services
{
    public class HttpService<T> : IHttpService<T> where T : BaseEntity
    {
        private const string ApiUrl = "https://swapi.dev/api";

        private readonly ILogger<Application> _logger;
        private readonly HttpClient _httpClient = new();
        private readonly T? _entity;

        public HttpService(ILogger<Application> logger)
        {
            _logger = logger;
            _entity = Activator.CreateInstance(typeof(T)) as T;

            _logger.LogInformation($"{nameof(HttpService<T>)} initialized");
        }
        
        public async Task<T?> HttpGetAsync()
        {
            try
            {
                _logger.LogInformation($"Running {nameof(HttpService<T>)}.{nameof(HttpGetAsync)}...");

                var url = $"{ApiUrl}{_entity!.GetUrlPath()}";

                _logger.LogInformation($"Making a call to {url}...");

                var result = await _httpClient.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Call to {url} unsuccessful, returning null");
                    return null;
                }

                _logger.LogInformation($"Call to {url} successful");

                return await FromHttpResponseMessage<T>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(HttpService<T>)}.{nameof(HttpGetAsync)} failed unexpectedly. Error: {ex}");

                return _entity;
            }
        }

        public async Task<T?> HttpGetAsync(string url)
        {
            try
            {
                _logger.LogInformation($"Running {nameof(HttpService<T>)}.{nameof(HttpGetAsync)} for {url}...");
                _logger.LogInformation($"Making a call to {url}...");

                var result = await _httpClient.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Call to {url} unsuccessful, returning null");
                    return null;
                }

                _logger.LogInformation($"Call to {url} successful");

                return await FromHttpResponseMessage<T>(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{nameof(HttpService<T>)}.{nameof(HttpGetAsync)}(string url) failed unexpectedly. Error: {ex}");

                return _entity;
            }
        }

        private async Task<T?> FromHttpResponseMessage<T>(HttpResponseMessage result)
        {
            _logger.LogInformation($"Deserializing {nameof(HttpResponseMessage)} content...");

            return JsonSerializer.Deserialize<T>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
