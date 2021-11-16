using Kenkata_ECommerce.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Models
{
    public class KenkataDbSettings : IKenkataDb
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ShoppingCartCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
    }
}
