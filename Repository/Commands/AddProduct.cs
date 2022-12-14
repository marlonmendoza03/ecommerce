using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Commands
{
    public partial class ProductCommandsRepository : IRepositoryCommands
    {
        public async Task<RepositoryResponse> AddProduct(Products products)
        {
            var response = new RepositoryResponse();
            try
            {
                await _appDbContext.AddAsync(products);
                await SaveChangesAsync();

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
