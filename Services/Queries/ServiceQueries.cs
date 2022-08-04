using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Queries
{
    public partial class ServiceQueries : IServiceQueries
    {
        private readonly IRepositoryQueries _repositoryQueries;

        public ServiceQueries(IRepositoryQueries repositoryQueries)
        {
            _repositoryQueries = repositoryQueries;
        }
    }
}

