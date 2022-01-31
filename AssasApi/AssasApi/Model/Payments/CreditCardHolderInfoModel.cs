using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class CreditCardHolderInfoModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CpfCnpj { get; set; }

        public string PostalCode { get; set; }

        public string AddressNumber { get; set; }

        public string AddressComplement { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }
    }
}
