using Application.Interfaces;
using CleanArchitecture.Infrastructure.NetWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Inventory
{
    public class InventoryService : IInventoryService
    {
        private const string AddressTemplate = "http://domainName/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"quantity\": {0}}}";
        private readonly IHttpClientWrapper _client;

        public InventoryService(IHttpClientWrapper client)
        {
            _client = client;
        }
        public void NotifySaleOccurred(int productId, int quantity)
        {
            var address = string.Format(AddressTemplate, productId);

            var json = string.Format(JsonTemplate, quantity);

            _client.Post(address, json);
        }
    }
}
