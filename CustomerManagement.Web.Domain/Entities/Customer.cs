using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Classification { get; protected set; }
        public string Name { get; protected set; }
        public string Phone { get; protected set; }
        public string Gender { get; protected set; }
        public string City { get; protected set; }
        public string Region { get; protected set; }
        public DateTime LastPurchase { get; protected set; }
        public Guid SellerId { get; protected set; }
        public User Seller { get; protected set; }

        public static Customer Create(
            string classification,
            string name,
            string phone,
            string gender,
            string city,
            string region,
            DateTime lastPurchase,
            Guid sellerId
            ) => new Customer()
            {
                Id = Guid.NewGuid(),
                Classification = classification,
                Name = name,
                Phone = phone,
                Gender = gender,
                City = city,
                Region = region,
                LastPurchase = lastPurchase,
                SellerId = sellerId
            };
    }
}
