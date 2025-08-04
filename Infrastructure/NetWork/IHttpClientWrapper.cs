using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.NetWork
{
    public interface IHttpClientWrapper
    {
        void Post(string address, string json);
    }
}
