using AssasApi.Data;
using AssasApi.Data.BLL;

namespace AssasApi
{
    public class AssasApi
    {
        public readonly CustomersBLL CustomersBLL = null;
        public AssasApi(ApiSettings apiSettings)
        {
            CustomersBLL = new CustomersBLL(apiSettings);
        }
    }
}
