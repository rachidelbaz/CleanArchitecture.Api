using API.Sales.Models;
using API.Sales.Services;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Domain.Employees;
using Domain.Sales;
using Microsoft.AspNetCore.Mvc;

namespace API.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IGetSalesListQuery _getSalesListQuery;
        private readonly IGetSaleDetailQuery _getSaleDetailQuery;
        private readonly ICreateSaleRequestModelFactory _createSaleRequestModelFactory;
        private readonly ICreateSaleCommand _createSaleCommand;

        public SalesController(
            IGetSalesListQuery  getSalesListQuery,
            IGetSaleDetailQuery  getSaleDetailQuery,
            ICreateSaleRequestModelFactory  createSaleRequestModelFactory,
            ICreateSaleCommand  createSaleCommand)
        {
            _getSalesListQuery = getSalesListQuery;
            _getSaleDetailQuery = getSaleDetailQuery;
            _createSaleRequestModelFactory = createSaleRequestModelFactory;
            _createSaleCommand = createSaleCommand;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var sales = _getSalesListQuery.Execute();

            return StatusCode(StatusCodes.Status200OK, sales);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Detail(int id)
        {
            var sale = _getSaleDetailQuery.Execute(id);

            return StatusCode(StatusCodes.Status200OK, sale);

        }

        //[Route("create")]
        //public IActionResult Create()
        //{
        //    var sale = _createSaleRequestModelFactory.Create();

        //    return StatusCode(StatusCodes.Status200OK, sale);

        //}

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateSaleRequestModel createSaleRequestModel)
        {
            var createdSaleModel = createSaleRequestModel.Sale;

            _createSaleCommand.Execute(createdSaleModel);

            return StatusCode(StatusCodes.Status200OK, createdSaleModel);
        }
    }
}
