using CustomerManagement.Web.Domain.Entities;
using System;

namespace CustomerManagement.Web.API.Model.Customers
{
    public class CustomerModel
    {
        public string Classification { get; protected set; }
        public string Name { get; protected set; }
        public string Phone { get; protected set; }
        public string Gender { get; protected set; }
        public string City { get; protected set; }
        public string Region { get; protected set; }
        public DateTime LastPurchase { get; protected set; }
        public string Seller { get; protected set; }

        public static CustomerModel Create(Customer customer) => new CustomerModel()
        {
            Classification = customer.Classification,
            Name = customer.Name,
            Phone = customer.Phone,
            Gender = customer.Gender,
            City = customer.City,
            Region = customer.Region,
            LastPurchase = customer.LastPurchase,
            Seller = customer.Seller.Name,

        };
    }
}
