using DesktopDiplomProject.Client.Features.Authentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Controllers
{
    public interface ICommController
    {
        public Task<TResponse?> GetAsync<TResponse>(string address, bool offMessage = false);
        public Task<TResponse?> GetAsync<TResponse>(string address, object? queryParams, bool offMessage = false);
        public Task<bool> GetAsync(string address, object? queryParams, bool offMessage = false);
        public Task<TResponse?> PostAsync<TRequest, TResponse>(string address, bool offMessage = false);
        public Task<TResponse?> PostAsync<TRequest, TResponse>(string address, TRequest request, bool offMessage = false);
        public Task<bool> PostAsync<TRequest>(string address, TRequest request, bool offMessage = false);
        public Task<TResponse?> PutAsync<TRequest, TResponse>(string address, bool offMessage = false);
        public Task<TResponse?> PutAsync<TRequest, TResponse>(string address, TRequest request, bool offMessage = false);
        public Task<bool> PutAsync<TRequest>(string address, TRequest request, bool offMessage = false);
        public Task<TResponse?> PatchAsync<TRequest, TResponse>(string address, TRequest request, bool offMessage = false);
        public Task<bool> PatchAsync<TRequest>(string address, TRequest request, bool offMessage = false);
        public Task<bool> DeleteAsync(string address, bool offMessage = false);
        public Task<bool> DeleteAsync(string address, object? queryParams, bool offMessage = false);
        public Task<TResponse?> DeleteAsync<TResponse>(string address, bool offMessage = false);
        public Task<TResponse?> DeleteAsync<TResponse>(string address, object? queryParams, bool offMessage = false);


    }
}
