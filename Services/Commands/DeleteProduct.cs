using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;
using Services.Validations;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        public async Task<ProductCommandsResponse> DeleteProduct(ProductCommands request)
        {
            var product = new ProductCommandsResponse();
            var serverErrorMsg = "Server Error";

            try
            {
                var productDataExists = await DataValidation.DeleteProductValidation(_repositoryQueries, request);

                if (productDataExists == null)
                {
                    return null;
                }

                var response = await _commandsRepository.DeleteProduct(new Products()
                {
                    ProductId = request.ProductId,
                });

                var getProductData = await _repositoryQueries.GetProductById(request.ProductId);
                product.ProductId = getProductData.ProductId;

                if (response.ResultMessage == serverErrorMsg)
                {
                    product.ResultMessage = serverErrorMsg;
                    return product;
                }
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
