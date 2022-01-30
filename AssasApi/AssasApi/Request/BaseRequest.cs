using AssasApi.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AssasApi.Data.Response;
using Newtonsoft.Json;

namespace AssasApi.Request
{
    public class BaseRequest
    {
        protected readonly ApiSettings _apiSettings = null;
        protected readonly HttpClient _httpClient = null;

        public BaseRequest(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            _httpClient = HttpClient();
            Head();
        }

        public async Task<Object<T>> PostAsync<T>(string route, object obj)
        {
            var content = new StringContent(obj == null ? string.Empty : JsonConvert.SerializeObject(obj), Encoding.UTF8, "");
            var response = await _httpClient.PostAsync(ApiRoute(route), content);

            return await ResponseRequest<T>(response);
        }
        public async Task<Object<T>> GetAsync<T>(string route, string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                route += $"/{id}";
            }
            var response = await _httpClient.GetAsync(ApiRoute(route));

            return await ResponseRequest<T>(response);
        }
        public async Task<ObjectList<T>> ListAsync<T>(string route, string filter = null)
        {
            if (!string.IsNullOrEmpty(filter))
                route += "?" + filter;

            var response = await _httpClient.GetAsync(ApiRoute(route));

            return await ResponseRequestList<T>(response);
        }
        public async Task DeleteAsync(string route, string id)
        {
            var response = await _httpClient.DeleteAsync(ApiRoute(route + $"/{id}"));
        }
        #region
        private HttpClient HttpClient()
        {
            return new HttpClient
            {
                BaseAddress = _apiSettings.BaseAddress,
                Timeout = _apiSettings.TimeOut,
            };
        }
        private void Head() => _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("access_token", _apiSettings.AccessToken);
        private string ApiRoute(string route) => $"/api/v3/{route}";
        private async Task<Object<T>> ResponseRequest<T>(HttpResponseMessage httpResponseMessage)
        {
            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            return new Object<T>(httpResponseMessage.StatusCode, result);
        }
        private async Task<ObjectList<T>> ResponseRequestList<T>(HttpResponseMessage httpResponseMessage)
        {
            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            return new ObjectList<T>(httpResponseMessage.StatusCode, result);
        }

        #endregion
    }
}
