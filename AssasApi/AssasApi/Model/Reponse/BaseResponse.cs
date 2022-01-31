using AssasApi.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Response
{
    public abstract class BaseResponse
    {
        public Notificacao Notificacao;
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

        public BaseResponse(HttpStatusCode httpStatusCode, string content)
        {
            Notificacao = new Notificacao();
            Erro(content, httpStatusCode);
        }

        private void Erro(string content, HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode != HttpStatusCode.OK)
            {
                var erro = httpStatusCode == HttpStatusCode.BadRequest ? BadRequest(content) : CodigoErroHTTP((StatusCode)httpStatusCode);
                Notificacao.Add(erro);
            }
        }
        private string BadRequest(string content)
        {
            var erroRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseErro>(content);
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
