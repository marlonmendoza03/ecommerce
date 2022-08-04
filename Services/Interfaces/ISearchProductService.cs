using Services.ServicesDTO;

namespace Services.Interfaces
{
    public interface ISearchProductService
    {
        public Task<List<ProductCommandsResponse>> SeachProductsService(SearchProductDetails searchProductDetails);
    }
}
