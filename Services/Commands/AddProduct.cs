using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public partial class ProductCommandsServices : ICommandsServices
    {
        public async Task<ProductCommandsResponse> AddProduct(ProductCommands productCommands)
        {
            var product = new ProductCommandsResponse();
            
            await _commandsRepository.AddProduct(new Products()
            {
                ProductName = productCommands.ProductName,
                ProductDescription = productCommands.ProductDescription,
                ProductPrice = productCommands.ProductPrice,
                ProductQuantity = productCommands.ProductQuantity,
                DateAdded = DateTime.Today
            });

            product = await Response(productCommands);
            return product;
        }

        private async Task<ProductCommandsResponse> Response(ProductCommands product)
        {
            var result = new ProductCommandsResponse()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                DateAdded = DateTime.Today
            };

            return result;
        }
    }
}
