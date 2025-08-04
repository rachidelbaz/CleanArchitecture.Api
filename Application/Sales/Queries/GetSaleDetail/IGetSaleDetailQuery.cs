﻿using Application.Sales.Queries.GetSalesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Queries.GetSaleDetail
{
    public interface IGetSaleDetailQuery
    {
        public SalesListItemModel Execute(int Id);
    }
}
