using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi
{
    public class Notificacao
    {
        private string _mensagem { get; set; }
        private bool _erro { get; set; }
        public Notificacao()
        {

        }
        public bool HasErro() => _erro;
        public string getMensage => _mensagem;

        public void Add(string msg,bool erro=true)
        {
            _erro = erro;
           _mensagem = msg;
        }


    }
}
