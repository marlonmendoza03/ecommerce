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
    public partial class ProductCommandsServices : IServiceCommands
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
            //product = await ProductResponse(productCommands);

            var response = new ProductCommandsResponse()
            {
                ProductId = productCommands.ProductId,
                ProductName = productCommands.ProductName,
                ProductDescription = productCommands.ProductDescription,
                ProductPrice = productCommands.ProductPrice,
                ProductQuantity = productCommands.ProductQuantity,
                DateAdded = productCommands.DateAdded
            };

            return response;
        }
        //private async Task<ProductCommandsResponse> ProductResponse(ProductCommands productCommands)
        //{
        //    var response = new ProductCommandsResponse()
        //    {
        //        ProductId = productCommands.ProductId,
        //        ProductName = productCommands.ProductName,
        //        ProductDescription = productCommands.ProductDescription,
        //        ProductPrice = productCommands.ProductPrice,
        //        ProductQuantity = productCommands.ProductQuantity,
        //        DateAdded = productCommands.DateAdded
        //    };

        //    return response;
        //}
    }
}
