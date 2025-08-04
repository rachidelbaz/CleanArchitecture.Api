using Application.Interfaces;
using Application.Sales.Queries.GetSalesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery : IGetSaleDetailQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetSaleDetailQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public SalesListItemModel Execute(int Id)
        {
            var sale = _databaseService.Sales.Where(s => s.Id == Id).Select(s => new SalesListItemModel()
            {
                Id = s.Id,
                Date = s.Date,
                CustomerName = s.Customer.Name,
                EmployeeName = s.Employee.Name,
                ProductName = s.Product.Name,
                UnitPrice = s.UnitPrice,
                Quantity = s.Quantity,
                TotalPrice = s.TotalPrice
            }).Single();
            return sale;
        }
    }
}
