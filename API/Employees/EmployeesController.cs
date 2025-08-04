using Application.Employees.Queries.GetEmployeesList;
using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace API.Employees
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController: ControllerBase
    {
        private readonly IGetEmployeesListQuery _getEmployeesListQuery;

        public EmployeesController(IGetEmployeesListQuery getEmployeesListQuery)
        {
            _getEmployeesListQuery = getEmployeesListQuery;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _getEmployeesListQuery.Execute();
            return StatusCode(StatusCodes.Status200OK,employees);
        }
    }
}
