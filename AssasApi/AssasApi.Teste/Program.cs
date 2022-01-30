using AssasApi.Data;
using AssasApi.Model.Customer;
using System;
using System.Threading.Tasks;

namespace AssasApi.Teste
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var setting = new ApiSettings("57757368f7603c7d19f7e7a248d9f5d7e393e92630ae9b073e2aa17d31c95ff7", TypeEnvironment.SANDBOX);
            AssasApi assasApi = new AssasApi(setting);
            try
            {
                var lista = await assasApi.CustomersBLL.ListAsync(new CustomerFilter());
                var a  =lista.Data;
            }
            catch (Exception e)
            {

            }
        }
    }
}
