using Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace API.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController:ControllerBase
    {
        private readonly IGetCustomersListQuery _getCustomersListQuery;

        public CustomersController(IGetCustomersListQuery getCustomersListQuery)
        {
            _getCustomersListQuery = getCustomersListQuery;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get() { 
        
            var customers=_getCustomersListQuery.Execute();

            return StatusCode(StatusCodes.Status200OK,customers);
        }
    }
}
