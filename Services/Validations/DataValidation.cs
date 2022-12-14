using Repository.Interfaces;
using Services.ServicesDTO;

namespace Services.Validations
{
    public static class DataValidation
    {
        public static async Task<ProductCommandsResponse> AddResponseValidation(IRepositoryQueries repositoryQueries, ProductCommands productCommands)
        {
            var product = new ProductCommandsResponse();

            var products = await repositoryQueries.GetAllProducts();

            bool productNameExists = products.Any(x => x.ProductName.ToLower() == productCommands.ProductName.ToLower());

            if (productNameExists)
            {
                return null;
            }

            return product;
        }

        public static async Task<ProductCommandsResponse> SearchProductValidation(IRepositoryQueries repositoryQueries, SearchProductDetails searchProductDetails)
        { 
            var productCommandResponse = new ProductCommandsResponse();
            var products = await repositoryQueries.GetAllProducts();
            bool productChecker = products.Any(x => x.ProductName.ToLower() == searchProductDetails.ProductName.ToLower() && x.ProductDescription.ToLower() == searchProductDetails.ProductDescription.ToLower());

            if (productChecker == null)
            {
                return null;
            }
            return productCommandResponse; 
        }
        public static async Task<ProductCommandsResponse> UpdateValidation(IRepositoryQueries repositoryQueries, ProductCommands productCommands)
        {
            var product = new ProductCommandsResponse();

            var products = await repositoryQueries.GetAllProducts();

            bool isIdExists = products.Any(i => i.ProductId == productCommands.ProductId);

            if (!isIdExists)
            {
                return null;
            };

            return product;
        }
        public static async Task<ProductCommandsResponse> DeleteProductValidation(IRepositoryQueries repositoryQueries, ProductCommands productCommands)
        {
            var product = new ProductCommandsResponse();

            var products = await repositoryQueries.GetAllProducts();

            bool activeStatus = products.Where(x => x.ProductId == productCommands.ProductId).Select(x => x.IsActive).FirstOrDefault();

            if (activeStatus == false)
            {
                return null;
            };

            return product;
        }
    }
}
