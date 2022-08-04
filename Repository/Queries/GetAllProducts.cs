﻿using Microsoft.EntityFrameworkCore;
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

            if (productName == null)
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

        public async Task<List<ProductDetails>> GetProductWithProductNameAndDesctiption(string? productName, string? productDescription)
        {
            var productChecker = await _dbContext.products.FirstOrDefaultAsync(x => x.ProductName.ToLower() == productName && x.ProductDescription == productDescription);

            if (productChecker == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(productDescription))
            {
                return null;
            }
            try
            {
                var query = from p in _dbContext.products
                            where (!string.IsNullOrEmpty(productName) && p.ProductName.ToLower().Contains(productName.ToLower()) || (!string.IsNullOrEmpty(productDescription) && p.ProductDescription.ToLower().Contains(productDescription.ToLower())))
                            select new ProductDetails
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                ProductPrice = p.ProductPrice,
                                ProductQuantity = p.ProductQuantity,
                                DateAdded = p.DateAdded
                            };
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                CloseConnection.DisposeConnection();
            }
        }
    }
}
