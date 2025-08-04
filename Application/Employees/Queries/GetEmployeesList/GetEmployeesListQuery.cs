using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IGetEmployeesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<EmployeeModel> Execute()
        {
           var employees = _databaseService.Employees.Select(e=>new EmployeeModel()
           {
                Id = e.Id,
                Name=e.Name,
           });
            return employees.ToList();
        }
    }
}
