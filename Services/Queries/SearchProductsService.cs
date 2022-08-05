using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;
using Services.Validations;

namespace Services.Queries
{
    public class SearchProductService : ISearchProductService
    {
        private readonly IRepositoryQueries _repositoryQueries;

        public SearchProductService(IRepositoryQueries repositoryQueries)
        {
            _repositoryQueries = repositoryQueries;
        }
        public async Task<List<ProductCommandsResponse>> SeachProductsService(SearchProductDetails searchProductDetails)
        {
            var errorMessage = new SearchProductDetails();
            List<ProductCommandsResponse> result = new List<ProductCommandsResponse>();
            var data = await _repositoryQueries.GetProductWithProductNameAndDesctiption(searchProductDetails.ProductName, searchProductDetails.ProductDescription);
            try
            {
                var productDataExists = await DataValidation.SearchProductValidation(_repositoryQueries, searchProductDetails);
                if (data == null || productDataExists == null)
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(searchProductDetails.ProductName) || !string.IsNullOrEmpty(searchProductDetails.ProductDescription))
                {
                    foreach (var item in data)
                    {
                        result.Add(new ProductCommandsResponse
                        {
                            ProductName = item.ProductName,
                            ProductDescription = item.ProductDescription,
                            ProductId = item.ProductId,
                            ProductPrice = item.ProductPrice,
                            ProductQuantity = item.ProductQuantity,
                            DateAdded = item.DateAdded.ToString("MM/dd/yyyy")
                        });
                    }
                }
            }
            catch (Exception e)
            {
                errorMessage.ResultMessage = "Server Error";
            }
            return result;
        }
    }
}

