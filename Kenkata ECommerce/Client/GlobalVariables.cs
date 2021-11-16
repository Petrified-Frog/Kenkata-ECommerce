using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Client
{
    public class GlobalVariables
    {
        public int cartItems { get; set; }
        public decimal cartSum { get; set; }
        public string cartId { get; set; }
        public bool orderPlaced { get; set; } = false;
        public ShoppingCartModel mainShoppingCart { get; set; } = null;
                
       
        public void SetCartItems(int items)
        {
            cartItems = items;
            NotifyCartItemsChanged();
        }
        public event Action OnCartItemsChange;
        private void NotifyCartItemsChanged() => OnCartItemsChange?.Invoke();

        public void SetCartSum(decimal sum)
        {
            cartSum = sum;
            NotifyCartSumChanged();
        }
        public event Action OnCartSumChange;
        private void NotifyCartSumChanged() => OnCartSumChange?.Invoke();
    }
}
