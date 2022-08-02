using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Queries
{
    public partial class ServiceQueries : IServiceQueries
    {
        async Task<List<OrdersDTO>> IServiceQueries.GetAllOrders()
        {
            var allOrders = await _repositoryQueries.GetAllOrders();

            List<OrdersDTO> result = new List<OrdersDTO>();

            if (allOrders == null)
            {
                return null;
            }

            foreach (var order in allOrders)
            {
                result.Add(new OrdersDTO
                {
                    order_id = order.order_id,
                    order_amount = order.order_amount,
                    ordered_by = order.ordered_by,
                    order_quantity = order.order_quantity,
                    order_date = order.order_date.Date.ToString("MM/dd/yyyy")
                });
            }

            return result;
        }
    }
}
