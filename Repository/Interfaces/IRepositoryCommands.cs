using Repository.RepositoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryCommands
    {
        Task<RepositoryResponse> AddProduct(Products products);
        Task<RepositoryResponse> UpdateProduct(Products products);
    }
}
