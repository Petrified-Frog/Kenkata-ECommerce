using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Interfaces
{
    public interface IShoppingCartCatalogService
    {
        Task<ShoppingCartModel> GetShoppingCartByIdAsync(string id);
        Task<ShoppingCartModel> AddToCart(ShoppingCartModel item);
        Task UpdateShoppingCartAsync(string id, ShoppingCartModel shopingCart);
        //Task DeleteItem(ShoppingCartModel item, string id);
        Task DeleteShoppingCartAsync(string id);
    }
}
