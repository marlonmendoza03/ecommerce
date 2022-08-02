using Repository.DataContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Commands
{
    public partial class ProductCommandsRepository : IRepositoryCommands
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        private async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
