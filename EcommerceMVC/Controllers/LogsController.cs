using EcommerceMVC.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EcommerceMVC.Controllers
{
    [Route("logs")]
    public class LogsController : Controller
    {
        private readonly IServiceQueries _serviceQueries;

        public LogsController(IServiceQueries serviceQueries)
        {
            _serviceQueries = serviceQueries;
        }

        [HttpGet]
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
    }
}
