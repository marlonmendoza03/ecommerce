using Services.ServicesDTO;

namespace Services.Interfaces
{
    public interface IServiceQueries
    {
        Task<List<LogsDTO>> GetAllLogs();
        Task<List<ProductsDTO>> GetAllProducts();
    }
}
