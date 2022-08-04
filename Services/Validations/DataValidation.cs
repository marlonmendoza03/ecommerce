using Repository.Interfaces;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task<ProductCommandsResponse> DeleteResponseValidation(IRepositoryQueries repositoryQueries, ProductCommands productCommands)
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
