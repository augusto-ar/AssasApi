using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Model.Payments
{
    public class PaymentModel
    {
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Customer { get; set; }

        public string Subscription { get; set; }

        public string Installment { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Value { get; set; }

        public decimal NetValue { get; set; }

        public DiscountModel Discount { get; set; }

        public InterestModel Interest { get; set; }

        public FineModel Fine { get; set; }

        public BillingType BillingType { get; set; }

        public PaymentStatus Status { get; set; }

        public string Description { get; set; }

        public string ExternalReference { get; set; }

        public DateTime OriginalDueDate { get; set; }

        public decimal? OriginalValue { get; set; }

        public decimal? InterestValue { get; set; }

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? ClientPaymentDate { get; set; }

        public string InvoiceUrl { get; set; }

        public string BankSlipUrl { get; set; }

        public string InvoiceNumber { get; set; }

        public bool Deleted { get; set; }

        public bool PostalService { get; set; }

        public bool Anticipated { get; set; }

        public CreditCardModel CreditCard { get; set; }

        public List<SplitModel> Split { get; set; }
    }
}
