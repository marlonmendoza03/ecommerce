using EcommerceMVC.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EcommerceMVC.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IServiceQueries _serviceQueries;

        public AdminController(IServiceQueries serviceQueries)
        {
            _serviceQueries = serviceQueries;
        }

        [HttpGet("logs")]
        public async Task<IActionResult> Logs()
        {
            var response = new LogsResponseModel();
            var logs = await _serviceQueries.GetAllLogs();
            var logsResponse = new List<LogsModel>();
            if (logs == null)
            {
                return null;
            }

            foreach (var logItems in logs)
            {
                logsResponse.Add(new LogsModel()
                {
                    LogId = logItems.LogId,
                    LogDescription = logItems.LogDescription,
                    LogDate = logItems.LogDate,
                    AddedBy = logItems.AddedBy
                });
            }

            response.Logs = logsResponse;
            return View(response);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders()
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
            return View(response);
        }
    }
}
