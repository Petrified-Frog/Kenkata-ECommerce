using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Interfaces
{
    public interface IOrderCatalogService
    {
        Task<List<OrderModel>> GetOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(string id);
        Task<OrderModel> UpdateOrderAsync(string id, OrderModel order);
        Task<string> CreateOrderAsync(OrderModel order);
        Task DeleteOrderAsync(string id);
    }
}
