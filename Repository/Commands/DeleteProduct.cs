using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Commands
{
    public partial class ProductCommandsRepository : IRepositoryCommands
    {
        public async Task<RepositoryResponse> DeleteProduct(Products products)
        {
            var response = new RepositoryResponse();
            try
            {
                var productDataExists = _appDbContext.products.FirstOrDefault(x => x.ProductId == products.ProductId && x.IsActive == true);

                if (productDataExists != null)
                {
                    productDataExists.IsActive = false;
                    await SaveChangesAsync();
                }

                response.ResultMessage = "Success";
            }
            catch (Exception)
            {
                response.ResultMessage = "Server Error";
            }
            finally
            {
                CloseConnection.DisposeConnection();
            }
            return response;
        }
    }
}