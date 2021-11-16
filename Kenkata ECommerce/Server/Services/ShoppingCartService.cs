using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Services
{
    public class ShoppingCartService : IShoppingCartCatalogService
    {
        private readonly IMongoCollection<ShoppingCartModel> _shoppingCart;

        public ShoppingCartService(IKenkataDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shoppingCart = database.GetCollection<ShoppingCartModel>(settings.ShoppingCartCollectionName);
        }

        public async Task<ShoppingCartModel> GetShoppingCartByIdAsync(string id) => await _shoppingCart.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<ShoppingCartModel> AddToCart(ShoppingCartModel item)
        {
            await _shoppingCart.InsertOneAsync(item);
            return item;
        }

        public async Task UpdateShoppingCartAsync(string id, ShoppingCartModel shopingCart) => await _shoppingCart.ReplaceOneAsync(p => p.Id == id, shopingCart);

        public async Task DeleteShoppingCartAsync(string id) => await _shoppingCart.DeleteOneAsync(p => p.Id == id);
    }
}
