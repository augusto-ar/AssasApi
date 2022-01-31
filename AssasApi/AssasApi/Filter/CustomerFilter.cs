using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssasApi.Filter
{
    public class CustomerFilter : BaseFilter
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string ExternalReference { get; set; }
        public string GroupName { get; set; }
        public string GetFilter()
        {
            string queryFilter = string.Empty;
            if (!string.IsNullOrEmpty(Name))
                queryFilter += "name=" + Name;
            if (!string.IsNullOrEmpty(Email))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&email=" : "email=" + Email;
            if (!string.IsNullOrEmpty(CpfCnpj))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&cpfCnpj=" : "cpfCnpj=" + CpfCnpj;
            if (!string.IsNullOrEmpty(ExternalReference))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&externalReference=" : "externalReference=" + ExternalReference;
            if (!string.IsNullOrEmpty(GroupName))
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&groupName=" : "groupName=" + GroupName;
            if (limit > 0)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&limit=" : "limit=" + limit.ToString();
            if (offset > 0)
                queryFilter += string.IsNullOrEmpty(queryFilter) ? "&offset=" : "offset=" + offset.ToString();

            return queryFilter;
        }
    }
}
