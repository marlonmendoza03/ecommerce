using Repository.DataContext;
using Repository.Interfaces;
using Repository.RepositoryDTO;
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
        public List<ShoppingCart> Cart;

        public ProductCommandsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Cart = new List<ShoppingCart>();
        }
        private async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
