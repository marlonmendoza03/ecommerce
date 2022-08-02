using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Logs>> GetAllLogs()
        {
            return await _dbContext.logs.ToListAsync();
        }
    }
}
