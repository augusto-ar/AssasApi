using System.Threading.Tasks;
using AssasApi.Request;
using AssasApi.Model.Payments;
using AssasApi.Model.Response;
using AssasApi.Filter;


namespace AssasApi.Data.BLL
{
    public class PaymentsBLL: BaseRequest
    {
        public PaymentsBLL(ApiSettings settings) : base(settings) { }

        public async Task<ResponseRequest<PaymentModel>> CreatAsync(CreatePaymentModel create)
        {
            return await PostAsync<PaymentModel>(paymentsRoute, create);
        }

        public async Task<ResponseRequest<PaymentModel>> UpdateAsync(UpdatePaymentModel update)
        {
            return await PostAsync<PaymentModel>($"{paymentsRoute}/{update.Id}", update);
        }

        public async Task<ResponseRequest<PaymentModel>> LoadAsync(string id)
        {
            return await GetAsync<PaymentModel>(paymentsRoute, id);
        }
        public async Task<ResponseRequest<PaymentModel>> ListAsync(PaymentFilter filter = null)
        {
            string queryFilter = filter != null? filter.GetFilter() : null;

            return await ListAsync<PaymentModel>(paymentsRoute, queryFilter);
        }

        public async Task DeleteAsync(string id = null)
        {
            await DeleteAsync(paymentsRoute, id);
        }
    }
}
