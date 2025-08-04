using Domain.Customers;
using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Customer() { Id = 1, Name = "Moudakir Hamza" },
                new Customer() { Id = 2, Name = "Dardouri khalid" },
                new Customer() { Id = 3, Name = "Elmolaoui Amine" });
        }
    }
}
