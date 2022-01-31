using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class SplitModel
    {
        public string WalletId { get; set; }

        public decimal FixedValue { get; set; }

        public decimal PercentualValue { get; set; }
    }
}
