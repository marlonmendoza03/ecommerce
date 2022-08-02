using Microsoft.EntityFrameworkCore;
using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Logs>> GetAllLogs()
        {
            try
            {
                return await _dbContext.logs.ToListAsync();
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
