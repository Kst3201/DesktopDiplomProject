using DesktopDiplomProject.Client.Services.URLBuilders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Controllers
{
    internal class HTTPSCommController : ICommController, IDisposable
    {
        private HttpMessageHandler _handler;
        private HttpClient _client;
        private IURLQueryBuilder _urlBuilder;
        private string? _token;

        public HTTPSCommController(IConfiguration configuration)
        {
            var baseURL = configuration["ApiSettings:BaseURL"] ?? throw new ArgumentNullException(nameof(configuration));
            _handler = new HttpClientHandler();
            _client = new HttpClient(_handler, true) { BaseAddress = new Uri(baseURL) };
            _urlBuilder = new NativeURLQueryBuilder();
        }

        public void SetAccessToken(string token)
        {
            _token = token;
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public bool IsAccessTokenValid(DateTime expiresAt)
        {
            return !string.IsNullOrEmpty(_token) && DateTime.UtcNow < expiresAt;
        }

        public void ClearAuth()
        {
            _token = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public void Dispose()
        {
            _client?.Dispose();
            _handler?.Dispose();
        }

        #region GET

        public async Task<TResponse?> GetAsync<TResponse>(string address)
        {
            var response = await _client.GetAsync(address);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"GET {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> GetAsync<TResponse>(string address, object? queryParams)
        {
            var response = await _client.GetAsync(_urlBuilder.Build(address, queryParams));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"GET {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> GetAsync(string address, object? queryParams)
        {
            var response = await _client.GetAsync(_urlBuilder.Build(address, queryParams));
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region POST

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string address)
        {
            var response = await _client.PostAsync(address, null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"POST {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string address, TRequest request)
        {
            var response = await _client.PostAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"POST {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PostAsync<TRequest>(string address, TRequest request)
        {
            var response = await _client.PostAsJsonAsync(address, request);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region PUT

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string address)
        {
            var response = await _client.PutAsync(address, null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PUT {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string address, TRequest request)
        {
            var response = await _client.PutAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PUT {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PutAsync<TRequest>(string address, TRequest request)
        {
            var response = await _client.PutAsJsonAsync(address, request);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region PATCH

        public async Task<TResponse?> PatchAsync<TRequest, TResponse>(string address, TRequest request)
        {
            var response = await _client.PatchAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PATCH {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PatchAsync<TRequest>(string address, TRequest request)
        {
            var response = await _client.PatchAsJsonAsync(address, request);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region DELETE
        
        public async Task<bool> DeleteAsync(string address)
        {
            var response = await _client.DeleteAsync(address);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string address, object? queryParams)
        {
            var response = await _client.DeleteAsync(_urlBuilder.Build(address, queryParams));
            return response.IsSuccessStatusCode;
        }
        
        public async Task<TResponse?> DeleteAsync<TResponse>(string address)
        {
            var response = await _client.DeleteAsync(address);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"DELETE {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string address, object? queryParams)
        {
            var response = await _client.DeleteAsync(_urlBuilder.Build(address, queryParams));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"DELETE {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        #endregion
    }
}
