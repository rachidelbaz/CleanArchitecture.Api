using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.NetWork
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public void Post(string address, string json)
        {
            using var client = new HttpClient();

            //client.PostAsJsonAsync(address, json);

        }
    }
}
