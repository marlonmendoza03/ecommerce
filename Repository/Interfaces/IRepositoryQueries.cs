﻿using Repository.RepositoryDTO;

namespace Repository.Interfaces
{
    public interface IRepositoryQueries
    {
        Task<List<Users>> GetAllUsers();
        Task<List<Logs>> GetAllLogs();
        Task<List<Orders>> GetAllOrders();
        Task<List<Products>> GetAllProductDetails();
    }
}
