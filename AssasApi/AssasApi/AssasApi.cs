using AssasApi.Data;
using AssasApi.Data.BLL;

namespace AssasApi
{
    public class AssasApi
    {
        public readonly CustomersBLL CustomersBLL = null;
        public readonly PaymentsBLL PaymentBLL = null;
        public AssasApi(ApiSettings apiSettings)
        {
            CustomersBLL = new CustomersBLL(apiSettings);
            PaymentBLL = new PaymentsBLL(apiSettings);
        }
    }
}
