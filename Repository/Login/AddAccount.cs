using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class GetUserPassword : ILoginRepositoryQuery
    {
        public async Task<RegisterRepositoryResponse> RegisterAccount(Users users)
        {
            var response = new RegisterRepositoryResponse();
            try
            {
                await _appDbContext.AddAsync(users);
                await _appDbContext.SaveChangesAsync();

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
