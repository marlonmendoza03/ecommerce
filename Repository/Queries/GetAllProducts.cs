using Microsoft.EntityFrameworkCore;
using Repository.ConnectionHandler;
using Repository.Interfaces;
using Repository.RepositoryDTO;

namespace Repository.Queries
{
    public partial class RepositoryQuery : IRepositoryQueries
    {
        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
                return await _dbContext.products.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection.DisposeConnection();
            }
        }

        public async Task<ProductDetails> GetProductwithName(string productName)
        {
            var response = new ProductDetails();

            if(productName == null)
            {
                return null;
            }

            response = await (from p in _dbContext.products
                              where p.ProductName.ToLower() == productName.ToLower()
                              select new ProductDetails
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  ProductDescription = p.ProductDescription,
                                  ProductPrice = p.ProductPrice,
                                  ProductQuantity = p.ProductQuantity,
                                  DateAdded = p.DateAdded
                              }).FirstOrDefaultAsync();

            return response;
        }

        public async Task<ProductReponse> GetProductById(int id)
        {
            var response = new ProductReponse();
            try
            {
                var result = await _dbContext.products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
                response = new ProductReponse()
                {
                    ProductId = result.ProductId,
                    ProductName = result.ProductName,
                    ProductDescription = result.ProductDescription,
                    ProductPrice = result.ProductPrice,
                    ProductQuantity = result.ProductQuantity
                };

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
