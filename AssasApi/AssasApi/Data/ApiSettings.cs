using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Data
{
    public class ApiSettings
    {
        private const string ProductionUrl = "https://www.asaas.com";
        private const string SandboxUrl = "https://sandbox.asaas.com";
        public string AccessToken { get; }
        public readonly Uri BaseAddress;
        public TimeSpan TimeOut { get; set; }

        public ApiSettings(string accessToken, TypeEnvironment asaasEnvironment)
        {
            AccessToken = accessToken;
            BaseAddress = new Uri(BuildBaseAddress(asaasEnvironment));
            TimeOut = TimeSpan.FromSeconds(60);
        }
        private string BuildBaseAddress(TypeEnvironment typeEnvironment)
        {
            return typeEnvironment.IsProduction() ? ProductionUrl :
                   typeEnvironment.IsSandbox() ? SandboxUrl :
                   throw new InvalidOperationException("AsaasEnvironment not supported");
        }
    }
}
