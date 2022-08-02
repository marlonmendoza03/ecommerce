using Microsoft.EntityFrameworkCore;
using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Products>> GetAllProductDetails()
        {
            return await _dbContext.products.ToListAsync();
        }
    }
}
