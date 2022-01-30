using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi
{
    public class Notificacao
    {
        private string _mensagemErro { get; set; }
        private string _mensagem { get; set; }
        private bool _erro { get; set; }
        public Notificacao()
        {

        }
        public bool HasErro() => _erro;

        public void Add(string msg,bool erro=true)
        {
            _erro = erro;

            if(erro)
                _mensagemErro = msg;
            else
                _mensagem =  msg;
        }

        public string getMensagemSucesso() => _mensagem;
        public string getMensagemErro => _mensagemErro;

    }
}
