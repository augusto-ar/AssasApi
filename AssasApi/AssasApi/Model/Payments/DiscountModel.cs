using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class DiscountModel
    {
        public decimal Value { get; set; }

        public int DueDateLimitDays { get; set; }

        public DiscountType Type { get; set; }
    }
}
