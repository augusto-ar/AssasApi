using AssasApi.Data;
using AssasApi.Filter;
using AssasApi.Model.Customer;
using AssasApi.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Teste
{
    public class CustomersTeste 
    {
        protected readonly AssasApi assasApi;
        public CustomersTeste()
        {
            var setting = new ApiSettings("57757368f7603c7d19f7e7a248d9f5d7e393e92630ae9b073e2aa17d31c95ff7", TypeEnvironment.SANDBOX);
            assasApi = new AssasApi(setting);
        }

        public async Task<ResponseRequest<CustomerModel>> TestCreat()
        {
            var respsota = await assasApi.CustomersBLL.CreatAsync(new CreateCustomerModel
            {
                Name = "João",
                Phone = "2730333333",
                MobilePhone = "27999555544",
                Email = "jojo@gmail.com"
            });
            return respsota;
        }
        public async Task<ResponseRequest<CustomerModel>> TestUpdate(CustomerModel custom)
        {
            var result = await assasApi.CustomersBLL.UpdateAsync(new UpdateCustomerModel
            {
                CustomerId = custom.Id,
                Name = "Marconde",
                Phone = "31999956633",
                MobilePhone = custom.MobilePhone,
                Email = "Casemiro@hotmail.com",
                Address = custom.Address,
                AdditionalEmails = custom.AdditionalEmails,
                Complement = custom.Complement,
                Province = custom.Province,
                PostalCode = custom.PostalCode,
                ExternalReference = custom.ExternalReference,
                NotificationDisabled = custom.NotificationDisabled,
                AddressNumber = custom.AddressNumber,
                MunicipalInscription = custom.MunicipalInscription,
                StateInscription = custom.State,
                Observations = custom.Observations,
            });

            return result;
        }
        public async Task TestDelete(string id)
        {
            await assasApi.CustomersBLL.DeleteAsync(id);
        }
        public async Task<ResponseRequest<CustomerModel>> TestGetAsync(string id)
        {
            var result = await assasApi.CustomersBLL.LoadAsync(id);
            return result;
        }
        public async Task<ResponseRequest<CustomerModel>> TestListAsync(CustomerFilter customerFilter=null)
        {
            var result = await assasApi.CustomersBLL.ListAsync(customerFilter);
           return result;
        }
    }
}
