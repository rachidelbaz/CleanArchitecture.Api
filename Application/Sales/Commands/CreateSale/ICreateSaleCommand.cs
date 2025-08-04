using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        public void Execute(CreateSaleModel createSaleModel);
    }
}
