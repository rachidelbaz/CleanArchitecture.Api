using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetCustomersListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        List<CustomerModel> IGetCustomersListQuery.Execute()
        {
            var customers = _databaseService.Customers.Select(c=>new CustomerModel()
            {
                Id = c.Id,
                Name = c.Name
            });

            return customers.ToList();
        }
    }
}
