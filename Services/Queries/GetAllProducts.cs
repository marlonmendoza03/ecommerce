using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Queries
{
    public partial class ServiceQueries : IServiceQueries
    {
        public async Task<List<ProductsDTO>> GetAllProducts()
        {
            var allProducts = await _repositoryQueries.GetAllProducts();

            List<ProductsDTO> result = new List<ProductsDTO>();

            if (allProducts == null)
            {
                return null;
            }

            foreach (var product in allProducts)
            {
                result.Add(new ProductsDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    DateAdded = product.DateAdded.Date.ToString("MM/dd/yyyy"),
                    IsActive = product.IsActive
                });
            }
            return result;
        }
    }
}
