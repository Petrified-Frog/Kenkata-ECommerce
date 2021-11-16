using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderCatalogService _orderCatalog;

        public OrdersController(IOrderCatalogService orderCatalog)
        {
            _orderCatalog = orderCatalog;
        }
        [HttpGet]
        public Task<List<OrderModel>> GetOrdersAsync() => _orderCatalog.GetOrdersAsync();

        [HttpGet("{id}")]
        public Task<OrderModel> GetOrderByIdAsync(string id) => _orderCatalog.GetOrderByIdAsync(id);

        [HttpPut("{id}")]
        public Task<OrderModel> UpdateOrderAsync(string id, OrderModel order) => _orderCatalog.UpdateOrderAsync(id, order);

        [HttpPost]
        public Task<string> CreateOrderAsync(OrderModel order) => _orderCatalog.CreateOrderAsync(order);

        [HttpDelete("{id}")]
        public Task DeleteOrderAsync(string id) => _orderCatalog.DeleteOrderAsync(id);
    }
}
