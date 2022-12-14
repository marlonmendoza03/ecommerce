using Repository.RepositoryDTO;

namespace Repository.Interfaces
{
    public interface IRepositoryQueries
    {
        Task<List<Users>> GetAllUsers();
        Task<List<Logs>> GetAllLogs();
        Task<List<Orders>> GetAllOrders();
        Task<List<Products>> GetAllProducts();
        Task<ProductReponse> GetProductById(int id);
        Task<ProductDetails> GetProductwithName(string productName);
        Task<List<ProductDetails>> GetProductWithProductNameAndDesctiption(string? productName, string? productDescription);
    }
}
