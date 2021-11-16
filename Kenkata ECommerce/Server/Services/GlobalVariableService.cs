using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Services
{
    public class GlobalVariableService
    {
        public static int CartItems { get; set; }
        public static string CartId { get; set; }
        public static bool OrderPlaced { get; set; } = false;
        public static ShoppingCartModel MainShoppingCart { get; set; } = null;

        public event Action OnCartItemsChange;
        public void SetCartItems(int newNr)
        {
            CartItems = newNr;
            NotifyCartItemsChanged();
        }
        private void NotifyCartItemsChanged() => OnCartItemsChange?.Invoke();
    }
}
