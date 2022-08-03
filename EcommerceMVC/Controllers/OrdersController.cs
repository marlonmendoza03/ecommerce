using Ecommerce.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Ecommerce.Controllers
{
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceQueries _serviceQueries;

        public OrdersController(IServiceQueries serviceQueries)
        {
            _serviceQueries = serviceQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _serviceQueries.GetAllOrders();
            var response = new OrdersResponse();
            List<OrdersResponseDTO> result = new List<OrdersResponseDTO>();

            if (orders == null)
            {
                return null;
            }

            foreach (var order in orders)
            {
                result.Add(new OrdersResponseDTO
                {
                    OrderId = order.order_id,
                    OrderedBy = order.ordered_by,
                    OrderAmount = order.order_amount,
                    OrderQuanity = order.order_quantity,
                    OrderDate = order.order_date
                });
            }

            response.Orders = result;
            return Ok(response);
        }
    }
}
