using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly ISaleFactory _saleFactory;
        private readonly IInventoryService _inventoryService;

        public CreateSaleCommand(IDatabaseService databaseService,ISaleFactory saleFactory,IInventoryService inventoryService)
        {
            _databaseService = databaseService;
            _saleFactory = saleFactory;
            _inventoryService = inventoryService;
        }
        public void Execute(CreateSaleModel model)
        {
            var date = DateTime.UtcNow;

            var customer = _databaseService.Customers
                .Single(p => p.Id == model.CustomerId);

            var employee = _databaseService.Employees
                .Single(p => p.Id == model.EmployeeId);

            var product = _databaseService.Products
                .Single(p => p.Id == model.ProductId);

            var quantity = model.Quantity;

            var sale = _saleFactory.Create(
                date,
                customer,
                employee,
                product,
                quantity);

            _databaseService.Sales.Add(sale);

            _databaseService.Save();

            _inventoryService.NotifySaleOccurred(product.Id, quantity);
        }
    }
}
