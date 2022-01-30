using System.Threading.Tasks;
using AssasApi.Request;
using AssasApi.Model.Customer;
using AssasApi.Data.Response;

namespace AssasApi.Data.BLL
{
    public class CustomersBLL : BaseRequest
    {
        private readonly string custormersRoute = "/customers";

        public CustomersBLL(ApiSettings settings) : base(settings) { }

        public async Task<Object<CustomerResponse>> CreatAsync(CreateCustomerRequest create)
        {
           return await PostAsync<CustomerResponse>(custormersRoute, create);
        }

        public async Task<Object<CustomerResponse>> UpdateAsync(UpdateCustomerRequest update)
        {
            return await PostAsync<CustomerResponse>(custormersRoute, update);
        }

        public async Task<Object<CustomerResponse>> ReadAsync(string id)
        {
            return await GetAsync<CustomerResponse>(custormersRoute, id);
        }
        public async Task<ObjectList<CustomerResponse>> ListAsync(CustomerFilter filter)
        {
            return await ListAsync<CustomerResponse>(custormersRoute, filter.GetFilter());
        }

        public async Task DeleteAsync(string id = null)
        {
            await DeleteAsync(custormersRoute,id);
        }
    }
}
