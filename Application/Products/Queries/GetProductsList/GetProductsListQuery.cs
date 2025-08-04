using Application.Interfaces;

namespace Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IGetProductsListQuery
    {
        private readonly IDatabaseService _databaseService;
        public GetProductsListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public List<ProductModel> Execute()
        {
            var products = _databaseService.Products.Select(p=>new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice=p.Price,
            }).ToList();
            return products;
        }
    }
}
