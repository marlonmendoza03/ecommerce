using Repository.Interfaces;
using Services.ServicesDTO;
namespace Services.Queries
{
    public partial class ServiceQueries
    {
        private readonly IRepositoryQueries _repositoryQueries;

        public ServiceQueries(IRepositoryQueries repositoryQueries)
        {
            _repositoryQueries = repositoryQueries;
        }
    }
}
