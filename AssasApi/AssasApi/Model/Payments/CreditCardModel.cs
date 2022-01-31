using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class CreditCardModel
    {
        public string CreditCardNumber { get; set; }

        public string CreditCardBrand { get; set; }

        public string CreditCardToken { get; set; }
    }
}
