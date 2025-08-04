using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Sales
{
    public class SaleConfiguration
           : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Date)
                .IsRequired();

            builder.HasOne(s => s.Customer);

            builder.Navigation(s => s.Customer)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(s => s.Employee);

            builder.Navigation(s => s.Employee)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(s => s.Product);

            builder.Navigation(s => s.Product)
                .IsRequired()
                .AutoInclude();

            builder.Property(s => s.TotalPrice)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.HasData(
                new
                {
                    Id = 1,
                    Date = DateTime.Parse("2025-08-02"),
                    CustomerId = 1,
                    EmployeeId = 1,
                    ProductId = 1,
                    UnitPrice = 90m,
                    Quantity = 1,
                    TotalPrice = 5m
                },
                new
                {
                    Id = 2,
                    Date = DateTime.Parse("2025-08-01"),
                    CustomerId = 2,
                    EmployeeId = 2,
                    ProductId = 2,
                    UnitPrice = 80m,
                    Quantity = 2,
                    TotalPrice = 20m
                },
                new
                {
                    Id = 3,
                    Date = DateTime.Parse("2025-08-03"),
                    CustomerId = 3,
                    EmployeeId = 3,
                    ProductId = 3,
                    UnitPrice = 40m,
                    Quantity = 3,
                    TotalPrice = 45m
                });
        }
    }
}
