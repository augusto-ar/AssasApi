using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class CreditCreditCardModel
    {
        public string HolderName { get; set; }

        public string Number { get; set; }

        public string ExpiryMonth { get; set; }

        public string ExpiryYear { get; set; }

        public string Ccv { get; set; }
    }
}
