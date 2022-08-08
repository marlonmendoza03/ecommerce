using Repository.DataContext;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery
    {
        private readonly AppDbContext _dbContext;
        public RepositoryQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
