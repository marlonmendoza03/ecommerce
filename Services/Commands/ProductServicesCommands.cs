using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        private readonly IRepositoryCommands _commandsRepository;
        private readonly IRepositoryQueries _repositoryQueries;

        public ProductCommandsServices(IRepositoryCommands commandsRepository, IRepositoryQueries repositoryQueries)
        {
            _commandsRepository = commandsRepository;
            _repositoryQueries = repositoryQueries;
        }

        private async Task<ProductCommandsResponse> ProductResponse(ProductCommands productCommands)
        {
            var res = await _repositoryQueries.GetProductwithName(productCommands.ProductName);

            var response = new ProductCommandsResponse()
            {
                ProductId = res.ProductId,
                ProductName = res.ProductName,
                ProductDescription = res.ProductDescription,
                ProductPrice = res.ProductPrice,
                ProductQuantity = res.ProductQuantity,
                DateAdded = res.DateAdded.Date.ToString("MM/dd/yyyy"),
                ProductProc = res.ProductProc,
                ProductRam = res.ProductRam,
                ProductStorage = res.ProductStorage
            };

            return response;
        }
    }
}
