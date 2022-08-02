using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Queries
{
    public partial class ServiceQueries : IServiceQueries
    {
        public async Task<List<ProductsDTO>> GetAllProducts()
        {
            var displayAllProducts = await _repositoryQueries.GetAllProductDetails();
            List<ProductsDTO> products = new List<ProductsDTO>();
            if (displayAllProducts == null)
            {
                return null;
            }
            foreach (var product in displayAllProducts)
            {
                products.Add(new ProductsDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    DateAdded = product.DateAdded
                });
            }
            return products;
        }
    }
}
