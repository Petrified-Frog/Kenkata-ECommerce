using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Services
{
    public class OrderCatalogService : IOrderCatalogService
    {
        private readonly IMongoCollection<OrderModel> _orders;

        public OrderCatalogService(IKenkataDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orders = database.GetCollection<OrderModel>(settings.OrderCollectionName);            
        }

        public async Task<List<OrderModel>> GetOrdersAsync()
        {
            var result = _orders.Find(p => true).ToListAsync();
            return await result;
        }

        public async Task<OrderModel> GetOrderByIdAsync(string id)
        {
            var result = _orders.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (result.Result == null) //Cant find the sought order. Return empty object
            {
                return new OrderModel();
            }
            return await result;
        }

        public async Task<string> CreateOrderAsync(OrderModel order)
        {
            await _orders.InsertOneAsync(order);
            return order.Id;
            //try
            //{
            //    var tmp = await _orders.InsertOneAsync(order);
            //    var result = _orders.Find(p => p.articleNr == product.articleNr).FirstOrDefaultAsync();
            //    return await result;
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public async Task<OrderModel> UpdateOrderAsync(string id, OrderModel order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

      

        

    }
}
