using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products
{
    public class ProductConfiguration
           : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.HasData(
                new Product() { Id = 1, Name = "Spaghetti", Price = 90m },
                new Product() { Id = 2, Name = "Pizza", Price = 80m },
                new Product() { Id = 3, Name = "Fish soup", Price = 40m });
        }
    }
}
