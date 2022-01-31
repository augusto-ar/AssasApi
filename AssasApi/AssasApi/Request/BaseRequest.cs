using AssasApi.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AssasApi.Model.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AssasApi.Request
{
    public class BaseRequest
    {
        protected readonly string paymentsRoute = "/payments";
        protected readonly string custormersRoute = "/customers";
        protected readonly ApiSettings _apiSettings = null;
        protected readonly HttpClient _httpClient = null;

        protected BaseRequest(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            _httpClient = new HttpClient{ BaseAddress = _apiSettings.BaseAddress };
            Head();
        }

        protected async Task<ResponseRequest<T>> PostAsync<T>(string route, object obj)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() }
            }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiRoute(route), content);

            return await ResponseRequest<T>(response,false);
        }
        protected async Task<ResponseRequest<T>> GetAsync<T>(string route, string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                route += $"/{id}";
            }
            var response = await _httpClient.GetAsync(ApiRoute(route));

            return await ResponseRequest<T>(response,false);
        }
        protected async Task<ResponseRequest<T>> ListAsync<T>(string route, string filter = null)
        {
            if (!string.IsNullOrEmpty(filter))
                route += "?" + filter;

            var response = await _httpClient.GetAsync(ApiRoute(route));

            return await ResponseRequest<T>(response,true);
        }
        protected async Task DeleteAsync(string route, string id)
        {
            var response = await _httpClient.DeleteAsync(ApiRoute(route + $"/{id}"));
        }
        #region
        private void Head() => _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("access_token", _apiSettings.AccessToken);
        private string ApiRoute(string route) => $"/api/v3/{route}";
        private async Task<ResponseRequest<T>> ResponseRequest<T>(HttpResponseMessage httpResponseMessage,bool ehLista)
        {
            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            return new ResponseRequest<T>(httpResponseMessage.StatusCode, result, ehLista);
        }
        
        #endregion
    }
}
