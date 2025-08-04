using API.DTOs;
using API.Sales.Models;
using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeesList;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Domain.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Sales.Services
{
    public class CreateSaleRequestModelFactory : ICreateSaleRequestModelFactory
    {
        private readonly IGetCustomersListQuery _getCustomersListQuery;
        private readonly IGetEmployeesListQuery _getEmployeesListQuery;
        private readonly IGetProductsListQuery _getProductsListQuery;

        public CreateSaleRequestModelFactory(IGetCustomersListQuery getCustomersListQuery,IGetEmployeesListQuery getEmployeesListQuery,IGetProductsListQuery getProductsListQuery)
        {
            _getCustomersListQuery = getCustomersListQuery;
            _getEmployeesListQuery = getEmployeesListQuery;
            _getProductsListQuery = getProductsListQuery;
        }
        public CreateSaleRequestModel Create()
        {
            var employees = _getEmployeesListQuery.Execute();
            var products = _getProductsListQuery.Execute();
            var customers=_getCustomersListQuery.Execute();

            var createRequest=new CreateSaleRequestModel();

            createRequest.Employees = employees
               .Select(e => new SelectOptionDto()
               {
                   Id = e.Id,
                   Name = e.Name
               })
               .ToList();

            createRequest.Customers = customers
                .Select(c => new SelectOptionDto()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            createRequest.Products = products
                .Select(p => new SelectOptionDto()
                {
                    Id = p.Id,
                    Name = p.Name + " ($" + p.UnitPrice + ")"
                })
                .ToList();

            createRequest.Sale = new CreateSaleModel();
            return createRequest;
        }
    }
}
