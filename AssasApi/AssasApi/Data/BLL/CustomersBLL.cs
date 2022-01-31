using System.Threading.Tasks;
using AssasApi.Request;
using AssasApi.Model.Customer;
using AssasApi.Model.Response;
using AssasApi.Filter;

namespace AssasApi.Data.BLL
{
    public class CustomersBLL : BaseRequest
    {

        public CustomersBLL(ApiSettings settings) : base(settings) { }

        public async Task<ResponseRequest<CustomerModel>> CreatAsync(CreateCustomerModel create)
        {
           return await PostAsync<CustomerModel>(custormersRoute, create);
        }

        public async Task<ResponseRequest<CustomerModel>> UpdateAsync(UpdateCustomerModel update)
        {
            return await PostAsync<CustomerModel>($"{custormersRoute}/{update.CustomerId}", update);
        }

        public async Task<ResponseRequest<CustomerModel>> LoadAsync(string id)
        {
            return await GetAsync<CustomerModel>(custormersRoute, id);
        }
        public async Task<ResponseRequest<CustomerModel>> ListAsync(CustomerFilter filter = null)
        {
            string queryFilter = filter != null ? filter.GetFilter() : null;

            return await ListAsync<CustomerModel>(custormersRoute, queryFilter);
        }

        public async Task DeleteAsync(string id = null)
        {
            await DeleteAsync(custormersRoute,id);
        }
    }
}
