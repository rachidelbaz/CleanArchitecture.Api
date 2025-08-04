using Domain.Customers;
using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                         new Employee() { Id = 1, Name = "El baz Rachid" },
                new Employee() { Id = 2, Name = "El baz hicham" },
                new Employee() { Id = 3, Name = "El baz abdelhack" });
        }
    }
}
