using Ecommerce.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Ecommerce.Controllers
{
    [Route("logs")]
    public class LogsController : Controller
    {
        private readonly IServiceQueries _serviceQueries;

        public LogsController(IServiceQueries serviceQueries)
        {
            _serviceQueries = serviceQueries;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logs()
        {
            var response = new LogsResponse();
            var logs = await _serviceQueries.GetAllLogs();
            var logsResponse = new List<LogsResponseDTO>();
            if (logs == null)
            {
                return null;
            }

            foreach (var logItems in logs)
            {
                logsResponse.Add(new LogsResponseDTO()
                {
                    LogId = logItems.LogId,
                    LogDescription = logItems.LogDescription,
                    LogDate = logItems.LogDate,
                    AddedBy = logItems.AddedBy
                });
            }

            response.Logs = logsResponse;
            return Ok(response);
        }
    }
}
