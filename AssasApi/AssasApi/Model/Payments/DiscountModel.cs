using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public DiscountType Type { get; set; }
    }
}
