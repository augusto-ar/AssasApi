using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Data.Response
{
    public class Error
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class ObjectErro
    {
        public List<Error> errors { get; set; }
    }
}
