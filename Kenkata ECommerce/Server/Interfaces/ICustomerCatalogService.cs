using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Interfaces
{
    public interface ICustomerCatalogService
    {
        Task<List<CustomerModel>> GetCustomerAsync();
        Task<CustomerModel> GetCustomerByIdAsync(string id);
        Task UpdateCustomerAsync(string id, CustomerModel product);
        Task CreateCustomerAsync(CustomerModel customer);
        Task DeleteCustomerAsync(string id);
    }
}
