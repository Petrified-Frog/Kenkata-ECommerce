using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Shared.Models
{
    public enum ParamOptions { Category, Tag, Brand };
    public enum MoreInfo { Descripion, Additional, Reviews, Brand };
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Stock { get; set; }
        public string articleNr { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string additionalinfo { get; set; }
        public string brand { get; set; }
        public string[] categories { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string[] images { get; set; }
        public string size { get; set; }
        public string[] tags { get; set; }
    }
}
