using System.Threading.Tasks;

namespace AssasApi.Teste
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var testeCliente = new CustomersTeste();
            var a = await testeCliente.TestListAsync();
        }
    }
}
