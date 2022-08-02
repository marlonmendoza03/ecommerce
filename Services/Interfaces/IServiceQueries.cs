using Services.ServicesDTO;

namespace Services.Interfaces
{
    public interface IServiceQueries
    {
        Task<List<LogsDTO>> GetAllLogs();
        Task<List<OrdersDTO>> GetAllOrders();
        Task<List<ProductsDTO>> GetAllProducts();
    }
}
