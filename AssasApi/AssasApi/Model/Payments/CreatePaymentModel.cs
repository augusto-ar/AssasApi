using System;
using System.Collections.Generic;


namespace AssasApi.Model.Payments
{
    public class CreatePaymentModel
    {
        public string customer { get; set; }

        public BillingType BillingType { get; set; }

        public decimal Value { get; set; }

        public DateTime? DueDate { get; set; }

        public string Description { get; set; }

        public string ExternalReference { get; set; }

        public int InstallmentCount { get; set; }

        public decimal InstallmentValue { get; set; }

        public DiscountModel Discount { get; set; }

        public InterestModel Interest { get; set; }

        public FineModel Fine { get; set; }

        public bool PostalService { get; set; }

        public CreditCreditCardModel CreditCard { get; set; }

        public CreditCardHolderInfoModel CreditCardHolderInfo { get; set; }

        public string RemoteIp { get; set; }

        public List<SplitModel> Split { get; set; }
    }
}
