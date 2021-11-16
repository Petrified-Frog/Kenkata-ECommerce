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
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartCatalogService _shoppingCartCatalog;

        public ShoppingCartController(IShoppingCartCatalogService shoppingCartCatalog)
        {
            _shoppingCartCatalog = shoppingCartCatalog;
        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("{id}")]
        public async Task<ShoppingCartModel> GetShoppingCartAsync(string id) => await _shoppingCartCatalog.GetShoppingCartByIdAsync(id);

        // POST api/<ShoppingCartController>
        [HttpPost]
        public async Task<ShoppingCartModel> CreateShoppingCartAsync(ShoppingCartModel shoppingCart) => await _shoppingCartCatalog.AddToCart(shoppingCart);

        // PUT api/<ShoppingCartController>/5
        [HttpPut("{id}")]
        public async Task UpdateShoppingCartAsync(string id, ShoppingCartModel shoppingCart) => await _shoppingCartCatalog.UpdateShoppingCartAsync(id, shoppingCart);

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public async Task DeleteShoppingCartAsync(string id) => await _shoppingCartCatalog.DeleteShoppingCartAsync(id);
    }
}
