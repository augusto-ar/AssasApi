using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class UpdatePaymentModel
    {
        public string Id { get; set; } 
        public string Customer { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BillingType? BillingType { get; set; }

        public decimal? Value { get; set; }

        public DateTime? DueDate { get; set; }

        public string Description { get; set; }

        public int? InstallmentCount { get; set; }

        public decimal? InstallmentValue { get; set; }

        public DiscountModel Discount { get; set; }

        public InterestModel Interest { get; set; }

        public FineModel Fine { get; set; }

        public bool? PostalService { get; set; }
    }
}
