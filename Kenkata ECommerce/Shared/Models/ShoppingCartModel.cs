using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Shared.Models
{
    public class ShoppingCartModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerID { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public List<CartItemModel> Products { get; set; } = new List<CartItemModel>();
    }
}
