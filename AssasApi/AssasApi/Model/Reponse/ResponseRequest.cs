using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AssasApi.Model.Response
{
    public class ResponseRequest<T> : BaseResponse
    {
        public List<T> ResultList { get; }
        public T Result { get; }

        public ResponseRequest(HttpStatusCode httpStatusCode, string content, bool list) : base(httpStatusCode, content)
        {
            if (httpStatusCode != HttpStatusCode.OK) return;

            if (list)
            {
                JObject listObject = JObject.Parse(content);
                ResultList = JsonConvert.DeserializeObject<List<T>>(listObject.GetValue("data").ToString());
            }
            else
                Result = JsonConvert.DeserializeObject<T>(content);
        }
    }
}
