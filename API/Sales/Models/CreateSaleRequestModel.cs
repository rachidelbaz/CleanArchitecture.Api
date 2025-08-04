using API.DTOs;
using Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Sales.Models
{
    public class CreateSaleRequestModel
    {
        public List<SelectOptionDto> Customers { get; set; }

        public List<SelectOptionDto> Employees { get; set; }

        public List<SelectOptionDto> Products { get; set; }

        public CreateSaleModel Sale { get; set; }
    }
}
