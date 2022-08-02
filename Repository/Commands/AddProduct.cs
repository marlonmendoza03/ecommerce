using Repository.Interfaces;
using Repository.RepositoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Commands
{
    partial class ProductCommandsRepository : IRepositoryCommands
    {
        public async Task AddProduct(Products products)
        {
            await _appDbContext.AddAsync(products);
            await SaveChangesAsync();
        }
    }
}
