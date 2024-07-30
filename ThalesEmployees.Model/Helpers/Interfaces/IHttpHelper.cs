using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Model.Helpers
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string url);

        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest content);

        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest content);

        Task DeleteAsync(string url);
    }
}
