using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Server.Interfaces
{
    public interface IKenkataDb
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ProductCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string ShoppingCartCollectionName { get; set; }
        string OrderCollectionName { get; set; }
    }
}
