using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenkata_ECommerce.Shared.Models
{
    public enum paymentMethods { direct_bank, check, cash, paypal};
    public enum shippingOptions { flat_rate, free, Local_pickup};

    public class OrderModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string ApartmentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> Products { get; set; } = new List<string>();
        public string CouponCode { get; set; }
        public shippingOptions ShippingOption { get; set; }
        public decimal Sum { get; set; }
        public paymentMethods PaymentMethod { get; set; }

        public string shippingFirstName { get; set; }
        public string shippingLastName { get; set; }
        public string shippingCompany { get; set; }
        public string shippingCountry { get; set; }
        public string shippingAddress1{ get; set; }
        public string shippingAddress2 { get; set; }
        public string shippingCity { get; set; }
        public string shippingState { get; set; }        
        public string shippingZip { get; set; }

}
}
