using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Users>> GetAllUsers()
        {
            return await _dbContext.users.ToListAsync();
        }
    }
}
