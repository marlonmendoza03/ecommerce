using Microsoft.EntityFrameworkCore;
using Repository.ConnectionHandler;
using Repository.DataContext;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public class GetUserPassword : ILoginRepositoryQuery
    {
        private readonly AppDbContext _appDbContext;

        public GetUserPassword(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<LoginRepositoryResponse> GetUserWithUsernameAndPassword(string username, string password)
        {
            var response = new LoginRepositoryResponse();
            try
            {
                var result = await _appDbContext.users.Where(x => (x.username.ToLower() == username.ToLower()) && (x.password == password)).FirstOrDefaultAsync();
                if (result != null)
                {
                    response = new LoginRepositoryResponse()
                    {
                        user_id = result.user_id,
                        username = result.username,
                        password = result.password,
                        roletype = result.roletype,
                        isActive = result.isActive
                    };
                }
            }
            catch (Exception e)
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

