using Application.Interfaces;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Infrastructure.Customers;
using Infrastructure.Employees;
using Infrastructure.Products;
using Infrastructure.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        DbSet<Customer> IDatabaseService.Customers { get; set; }
        DbSet<Employee> IDatabaseService.Employees { get; set; }
        DbSet<Product> IDatabaseService.Products { get; set; }
        DbSet<Sale> IDatabaseService.Sales { get; set; }

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        public void Save()
        {
            this.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("CleanArchitecture");

            dbContextOptionsBuilder.UseSqlServer(connectionString);
            //dbContextOptionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {base.OnModelCreating(builder);
            new CustomerConfiguration().Configure(builder.Entity<Customer>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new ProductConfiguration().Configure(builder.Entity<Product>());
            new SaleConfiguration().Configure(builder.Entity<Sale>());
        }
    }
}
