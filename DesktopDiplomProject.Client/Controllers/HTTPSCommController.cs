using DesktopDiplomProject.Client.Features.Authentification.Models;
using DesktopDiplomProject.Client.Managers.Sessions;
using DesktopDiplomProject.Client.Services.URLBuilders;
using DiplomDataLibrary.Authentification.Requests;
using DiplomDataLibrary.Authentification.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Controllers
{
    public class HTTPSCommController : ICommController, IDisposable
    {
        private HttpMessageHandler _handler;
        private HttpClient _client;
        private ISessionManager _sessionManager;
        private IURLQueryBuilder _urlBuilder;
        private string? _token;

        public HTTPSCommController(IConfiguration configuration, ISessionManager sessionManager)
        {
            var baseURL = configuration["ApplicationSettings:BaseURL"] ?? throw new ArgumentNullException(nameof(configuration));
            _handler = new HttpClientHandler();
            _client = new HttpClient(_handler, true) { BaseAddress = new Uri(baseURL) };
            _urlBuilder = new NativeURLQueryBuilder();
            _sessionManager = sessionManager;
            _sessionManager.UserChanged += OnUserChanged;
        }

        public bool IsAccessTokenValid(DateTime expiresAt)
        {
            return !string.IsNullOrEmpty(_token) && DateTime.UtcNow < expiresAt;
        }

        public void Dispose()
        {
            _client?.Dispose();
            _handler?.Dispose();
            _sessionManager.UserChanged -= OnUserChanged;
        }

        #region GET

        public async Task<TResponse?> GetAsync<TResponse>(string address)
        {
            await RefreshToken();
            var response = await _client.GetAsync(address);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"GET {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> GetAsync<TResponse>(string address, object? queryParams)
        {
            await RefreshToken();
            var response = await _client.GetAsync(_urlBuilder.Build(address, queryParams));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"GET {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> GetAsync(string address, object? queryParams)
        {
            await RefreshToken();
            var response = await _client.GetAsync(_urlBuilder.Build(address, queryParams));
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region POST

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string address)
        {
            await RefreshToken();
            var response = await _client.PostAsync(address, null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"POST {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PostAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"POST {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PostAsync<TRequest>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PostAsJsonAsync(address, request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ошибка {response.StatusCode}: {error}");
                // или выбросить исключение с деталями
                throw new HttpRequestException($"Ошибка {response.StatusCode}: {error}");
            }
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region PUT

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string address)
        {
            await RefreshToken();
            var response = await _client.PutAsync(address, null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PUT {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PutAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PUT {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PutAsync<TRequest>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PutAsJsonAsync(address, request);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region PATCH

        public async Task<TResponse?> PatchAsync<TRequest, TResponse>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PatchAsJsonAsync(address, request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"PATCH {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<bool> PatchAsync<TRequest>(string address, TRequest request)
        {
            await RefreshToken();
            var response = await _client.PatchAsJsonAsync(address, request);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region DELETE
        
        public async Task<bool> DeleteAsync(string address)
        {
            await RefreshToken();
            var response = await _client.DeleteAsync(address);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string address, object? queryParams)
        {
            await RefreshToken();
            var response = await _client.DeleteAsync(_urlBuilder.Build(address, queryParams));
            return response.IsSuccessStatusCode;
        }
        
        public async Task<TResponse?> DeleteAsync<TResponse>(string address)
        {
            await RefreshToken();
            var response = await _client.DeleteAsync(address);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"DELETE {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string address, object? queryParams)
        {
            await RefreshToken();
            var response = await _client.DeleteAsync(_urlBuilder.Build(address, queryParams));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            throw new HttpRequestException($"DELETE {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
        }

        #endregion

        private void Login(UserModel user)
        {
            _token = user.AccessToken.Token;
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }

        private void Logout()
        {
            _token = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        private bool IsTokenRefreshRequired()
        {
            UserModel? user = _sessionManager.User;
            if (user == null) return false;
            return user.AccessToken.ExpiresAt <= DateTime.UtcNow;
        }

        private async Task RefreshToken()
        {
            if (_sessionManager == null) throw new ArgumentNullException(nameof(_sessionManager));
            if (!IsTokenRefreshRequired()) return;
            UserModel? user = _sessionManager.User;
            if (user == null) return;
            var request = new RefreshRequest(user.AccessToken.Token, user.RefreshToken.Token);
            string address = "api/authentification/refresh";
            AuthentificationResponse? answer = null;
            var response = await _client.PostAsJsonAsync(address, request);
            if (response.IsSuccessStatusCode)
            {
                answer = await response.Content.ReadFromJsonAsync<AuthentificationResponse>();
            }
            else
            {
                throw new HttpRequestException($"POST {address} failed. Server returned status code: {(int)response.StatusCode} ({response.StatusCode}).");
            }
            if (answer == null) throw new ArgumentNullException($"{nameof(response)} is not initialized");
            user.AccessToken = new TokenModel(answer.AccessToken, answer.AccessTokenExpiresAt);
            user.RefreshToken = new TokenModel(answer.RefreshToken, answer.RefreshTokenExpiresAt);
            Logout();
            Login(user);
        }

        private void OnUserChanged(object? sender, UserChangedArgs e)
        {
            if (e.NewUser != null)
            {
                Login(e.NewUser);
            }
            else
            {
                Logout();
            }
            return;
        }
    }
}
