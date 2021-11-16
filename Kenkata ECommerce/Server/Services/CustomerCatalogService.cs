using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Services
{
    public class CustomerCatalogService : ICustomerCatalogService
    {
        private readonly IMongoCollection<CustomerModel> _customers;

        public CustomerCatalogService(IKenkataDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<CustomerModel>(settings.CustomerCollectionName);
        }

        /// <summary>
        /// Get all customer
        /// </summary>
        /// <returns>Return a list of customers</returns>
        public async Task<List<CustomerModel>> GetCustomerAsync() => await _customers.Find(p => true).ToListAsync();

        /// <summary>
        /// Get a customer by id
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns>Return one customer</returns>
        public async Task<CustomerModel> GetCustomerByIdAsync(string id) => await _customers.Find(p => p.Id == id).FirstOrDefaultAsync();

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="id">Id of the customer</param>
        /// <param name="customer">Customer model</param>
        /// <returns></returns>
        public async Task UpdateCustomerAsync(string id, CustomerModel customer) => await _customers.ReplaceOneAsync(p => p.Id == id, customer);

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer">The new customer</param>
        /// <returns></returns>
        public async Task CreateCustomerAsync(CustomerModel customer) => await _customers.InsertOneAsync(customer);

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns></returns>
        public async Task DeleteCustomerAsync(string id) => await _customers.DeleteOneAsync(p => p.Id == id);
    }
}
