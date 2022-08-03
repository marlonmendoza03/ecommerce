using Repository.ConnectionHandler;
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
        public async Task<RepositoryResponse> AddProduct(Products products)
        {
            var response = new RepositoryResponse();
            try
            {
                await _appDbContext.AddAsync(products);
                await SaveChangesAsync();

                response.ResultMessage = "Success";
            }
            catch (Exception)
            {
                response.ResultMessage = "Server Error";
            }
            finally
            {
                CloseConnection.DisposeConnection();
            }
            return response;
        }
    }
}
