using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;
using Services.Validations;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        public async Task<ProductCommandsResponse> UpdateProduct(ProductCommands productCommands)
        {
            var product = new ProductCommandsResponse();
            var serverErrorMsg = "Server Error";
            try
            {
                var validation = await DataValidation.UpdateValidation(_repositoryQueries, productCommands);

                if (validation == null)
                {
                    return null;
                }

                var response = await _commandsRepository.UpdateProduct(new Products()
                {
                    ProductId = productCommands.ProductId,
                    ProductName = productCommands.ProductName,
                    ProductDescription = productCommands.ProductDescription,
                    ProductPrice = productCommands.ProductPrice,
                    ProductQuantity = productCommands.ProductQuantity,
                    DateAdded = DateTime.Now
                });

                if (response.ResultMessage == serverErrorMsg)
                {
                    product.ResultMessage = serverErrorMsg;
                    return product;
                }

                product = await ProductResponse(productCommands);
                product.ResultMessage = "Success";
            }
            catch (Exception)
            {
                product.ResultMessage = serverErrorMsg;
            }

            return product;
        }
    }
}