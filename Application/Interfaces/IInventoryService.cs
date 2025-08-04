using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInventoryService
    {
        public void NotifySaleOccurred(int productId, int quantity);
    }
}
