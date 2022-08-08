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
        public async Task<RepositoryResponse> UpdateProduct(Products products)
        {
            var response = new RepositoryResponse();
            try
            {
                var idExists = _appDbContext.products.FirstOrDefault(i => i.ProductId == products.ProductId);
                if (idExists != null && idExists.ProductId == products.ProductId)
                {
                    idExists.ProductName = products.ProductName;
                    idExists.ProductDescription = products.ProductDescription;
                    idExists.ProductPrice = products.ProductPrice;
                    idExists.ProductQuantity = products.ProductQuantity;
                    idExists.ProductImage1 = products.ProductImage1;
                    idExists.ProductImage2 = products.ProductImage2;
                    idExists.ProductImage3 = products.ProductImage3;
                    idExists.DateAdded = products.DateAdded;
                }
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
