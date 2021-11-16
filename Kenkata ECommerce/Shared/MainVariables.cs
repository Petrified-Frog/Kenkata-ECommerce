using Kenkata_ECommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Shared
{
    public static class MainVariables
    {
        public static int CartItems { get; set; }
        public static string CartId { get; set; }
        public static bool OrderPlaced { get; set; } = false;
        public static ShoppingCartModel MainShoppingCart { get; set; } = null;
    }
}
