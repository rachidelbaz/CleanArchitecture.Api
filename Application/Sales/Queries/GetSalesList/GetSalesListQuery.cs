using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery : IGetSalesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetSalesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        List<SalesListItemModel> IGetSalesListQuery.Execute()
        {
            var sales = _databaseService.Sales.Select(s=>new SalesListItemModel()
            {
                Id = s.Id,
                Date = s.Date,
                CustomerName = s.Customer.Name,
                EmployeeName = s.Employee.Name,
                ProductName = s.Product.Name,
                UnitPrice = s.UnitPrice,
                Quantity = s.Quantity,
                TotalPrice = s.TotalPrice
            });
            return sales.ToList();
        }
    }
}
