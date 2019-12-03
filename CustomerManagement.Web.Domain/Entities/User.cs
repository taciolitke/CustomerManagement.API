using CustomerManagement.Web.Domain.Services;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Web.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Role { get; protected set; }
        public IEnumerable<Customer> Customers { get; protected set; }
        public static User Create(string email, string name, string password, string role) => new User()
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = name,
            Password = Md5Service.GetMd5Hash(password),
            Role = role
        };
    }
}
