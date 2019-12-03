using CustomerManagement.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManagement.Web.Repository.DataBase.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {

            var seller1 = User.Create("seller1@app.com", "Seller 1", "seller@1", Role.SELLER);
            var seller2 = User.Create("seller2@app.com", "Seller 2", "seller@2", Role.SELLER);

            builder.Entity<User>()
               .HasData(
                   User.Create("admin@app.com", "ADM", "admin@123", Role.ADMINISTRATOR),
                   seller1,
                   seller2
                   ); 
            
            builder.Entity<Customer>()
               .HasData(
                   Customer.Create("Medium", "Name 1", "555555555", "Male", "Brasília", "Brazil", DateTime.Now.AddDays(-10), seller1.Id),
                   Customer.Create("High", "Name 2", "555555555", "Female", "Brasília", "Brazil", DateTime.Now.AddDays(-60), seller1.Id),
                   Customer.Create("Low", "Name 3", "555555555", "Male", "Santiago", "Chile", DateTime.Now.AddDays(-11), seller1.Id),
                   Customer.Create("Medium", "Name 4", "555555555", "Male", "Brasília", "Brazil", DateTime.Now.AddDays(-14), seller1.Id),
                   Customer.Create("High", "Name 5", "555555555", "Female", "Brasília", "Brazil", DateTime.Now.AddDays(-15), seller1.Id),
                   Customer.Create("Medium", "Name 6", "555555555", "Male", "Santiago", "Chile", DateTime.Now.AddDays(-90), seller1.Id),
                   Customer.Create("Low", "Name 7", "555555555", "Male", "Santiago", "Chile", DateTime.Now.AddDays(-20), seller2.Id),
                   Customer.Create("Medium", "Name 8", "555555555", "Female", "Brasília", "Brazil", DateTime.Now.AddDays(-3), seller2.Id),
                   Customer.Create("Low", "Name 9", "555555555", "Male", "Brasília", "Brazil", DateTime.Now.AddDays(-4), seller2.Id),
                   Customer.Create("High", "Name 10", "555555555", "Female", "Brasília", "Brazil", DateTime.Now.AddDays(-85), seller2.Id),
                   Customer.Create("Medium", "Name 11", "555555555", "Male", "Brasília", "Brazil", DateTime.Now.AddDays(-16), seller2.Id),
                   Customer.Create("Low", "Name 12", "555555555", "Female", "Brasília", "Brazil", DateTime.Now.AddDays(-7), seller2.Id)
                   );
        }
    }
}
