using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        private readonly IRepositoryCommands _commandsRepository;
        private readonly IRepositoryQueries _repositoryQueries;

        public ProductCommandsServices(IRepositoryCommands commandsRepository, IRepositoryQueries repositoryQueries)
        {
            _commandsRepository = commandsRepository;
            _repositoryQueries = repositoryQueries;
        }
    }
}
