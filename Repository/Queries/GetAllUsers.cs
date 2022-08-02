using Microsoft.EntityFrameworkCore;
using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                return await _dbContext.users.ToListAsync();
            }
            catch
            {
                return null;
            }
            finally
            {
                CloseConnection.DisposeConnection();
            }
        }
    }
}
