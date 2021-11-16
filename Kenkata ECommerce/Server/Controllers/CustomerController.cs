using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kenkata_ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerCatalogService _customerCatalog;

        public CustomerController(ICustomerCatalogService customerCatalog)
        {
            _customerCatalog = customerCatalog;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<CustomerModel>> GetCustomerAsync() => await _customerCatalog.GetCustomerAsync();

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerModel> GetCustomerByIdAsync(string id) => await _customerCatalog.GetCustomerByIdAsync(id);

        // POST api/<CustomerController>
        [HttpPost]
        public async Task CreateCustomerAsync(CustomerModel customer) => await _customerCatalog.CreateCustomerAsync(customer);

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task UpdateCustomerAsync(string id, CustomerModel customer) => await _customerCatalog.UpdateCustomerAsync(id, customer);

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task DeleteCustomerAsync(string id) => await _customerCatalog.DeleteCustomerAsync(id);
    }
}
