using System.Net;
using Newtonsoft.Json;

namespace AssasApi.Data.Response
{
    public class Object<T>
    {
        public T Data { get; }

        public Object(HttpStatusCode httpStatusCode, string content)
        {
            if (httpStatusCode != HttpStatusCode.OK) return;

            Data = JsonConvert.DeserializeObject<T>(content);
        }
    }
}
