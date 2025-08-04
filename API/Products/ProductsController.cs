using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace API.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IGetProductsListQuery _productsListQuery;
        public ProductsController(IGetProductsListQuery productsListQuery)
        {
            _productsListQuery = productsListQuery;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var products=_productsListQuery.Execute();

            return StatusCode(StatusCodes.Status200OK,products);
        }

    }
}
