using AssasApi.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Data.Response
{
    public abstract class BaseObject
    {
        private HttpStatusCode HttpStatusCode;
        public Notificacao Notificacao;
        private string ResponseData;
        private enum StatusCode
        {
            [Description("Não foi enviada API Key ou ela é inválida.")]
            Unauthorized = 401,
            [Description("Requisição não autorizada. Abuso da API ou uso de parâmetros não permitidos podem gerar este código.")]
            Forbidden = 403,
            [Description("O endpoint ou o objeto solicitado não existe.")]
            NotFound = 404,
            [Description("Muitos pedidos em um determinado período de tempo.")]
            TooMany = 429,
            [Description("Algo deu errado no servidor do Asaas.")]
            InternalServerError = 500
        }

        public BaseObject(HttpStatusCode httpStatusCode, string content)
        {
            Notificacao = new Notificacao();
            HttpStatusCode = httpStatusCode;
            ResponseData = content;
            Erro();
        }

        private void Erro()
        {
            if (HttpStatusCode != HttpStatusCode.OK)
            {
                var erro = HttpStatusCode == HttpStatusCode.BadRequest ? BadRequest() : CodigoErroHTTP((StatusCode)HttpStatusCode);
                Notificacao.Add(erro);
            }
        }
        private string BadRequest()
        {
            var erroRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectErro>(ResponseData);
            return erroRequest != null && erroRequest.errors.Count() > 0 ? erroRequest.errors.Select(x => x.description)
                                 .ToList().Aggregate((i, j) => i + "," + j) : "erro";
        }
        private string CodigoErroHTTP(StatusCode statusCode)
        {
            if (statusCode == 0)
                return "Erro não identificado, contate o suporte";
            else
                return statusCode.GetDescricao();
        }
    }
}
