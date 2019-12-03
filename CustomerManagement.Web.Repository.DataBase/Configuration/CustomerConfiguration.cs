using CustomerManagement.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Repository.DataBase.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.LastPurchase).IsRequired();
            builder.Property(x => x.SellerId).IsRequired();

            builder.HasOne(x => x.Seller).WithMany(x => x.Customers).HasForeignKey(x => x.SellerId);
        }
    }
}
