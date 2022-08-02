using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public partial class ProductCommandsServices : ICommandsServices
    {
        private readonly ICommandsRepository _commandsRepository;

        public ProductCommandsServices(ICommandsRepository commandsRepository)
        {
            _commandsRepository = commandsRepository;
        }
    }
}
