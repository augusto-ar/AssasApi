using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Filter
{
    public class PaymentFilter : BaseFilter
    {
        public string Customer { get; set; }
        public string Subscription { get; set; }
        public string Installment { get; set; }
        public BillingType? BillingType { get; set; }
        public PaymentStatus? Status { get; set; }
        public string ExternalReference { get; set; }
        public DateTime? PaymentDateGE { get; set; }
        public DateTime? PaymentDateLE { get; set; }
        public DateTime? DueDateGE { get; set; }
        public DateTime? DueDateLE { get; set; }

        public string GetFilter()
        {
            string queryFilter = string.Empty;
            if (!string.IsNullOrEmpty(Customer))
                queryFilter += "customer=" + Customer;
            if (!string.IsNullOrEmpty(Subscription))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&subscription=" : "subscription=" + Subscription;
            if (!string.IsNullOrEmpty(ExternalReference))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&externalReference=" : "externalReference=" + ExternalReference;
            if(PaymentDateGE.HasValue)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&paymentDate[ge]=" : "paymentDate[ge]=" + PaymentDateGE.Value.ToString("yyyy-MM-dd");
            if (PaymentDateLE.HasValue)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&paymentDate[le]=" : "paymentDate[le]=" + PaymentDateLE.Value.ToString("yyyy-MM-dd");
            if (DueDateGE.HasValue)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&dueDate[ge]=" : "dueDate[ge]=" + DueDateGE.Value.ToString("yyyy-MM-dd");
            if (DueDateLE.HasValue)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&dueDate[le]=" : "dueDate[le]=" + DueDateLE.Value.ToString("yyyy-MM-dd");
            if (limit > 0)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&limit=" : "limit=" + limit.ToString();
            if (offset > 0)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&offset=" : "offset=" + offset.ToString();

            return queryFilter;
        }
    }
}
