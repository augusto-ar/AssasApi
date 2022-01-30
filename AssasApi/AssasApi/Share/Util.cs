using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AssasApi
{
    public static class ByteTypeExtensions
    {
        public static string GetDescricao(this System.Enum obj)
        {
            var enumType = obj.GetType();
            var field = enumType.GetField(obj.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
    public static class TypeEnvironmentExtension
    {
        public static bool IsProduction(this TypeEnvironment typeEnvironment)
        {
            return typeEnvironment == TypeEnvironment.PRODUCTION;
        }

        public static bool IsSandbox(this TypeEnvironment typeEnvironment)
        {
            return typeEnvironment == TypeEnvironment.SANDBOX;
        }
    }
    public enum TypeEnvironment
    {
        SANDBOX,
        PRODUCTION
    }
    public enum PersonType
    {
        FISICA, JURIDICA
    }
    public enum BillingType
    {
        BOLETO = 1,
        CREDIT_CARD = 2,
        PIX = 3,
        UNDEFINED = 4
    }
    public enum StatusCobranca
    {
        RECEIVED = 1,
        CONFIRMED = 2,
        OVERDUE = 3,
        REFUNDED = 4,
        RECEIVED_IN_CASH = 5,
        REFUND_REQUESTED = 6,
        CHARGEBACK_REQUESTED = 7,
        CHARGEBACK_DISPUTE = 8,
        AWAITING_CHARGEBACK_REVERSAL = 9,
        DUNNING_REQUESTED = 10,
        DUNNING_RECEIVED = 11,
        AWAITING_RISK_ANALYSIS = 12,
        PENDING = 13,
    }
}
