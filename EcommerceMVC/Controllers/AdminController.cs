using Ecommerce.EcommerceDTOs;
using EcommerceMVC.EcommerceDTOs;
using EcommerceMVC.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace EcommerceMVC.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IServiceQueries _serviceQueries;
        private readonly IServiceCommands _commandsServices;

        public AdminController(IServiceQueries serviceQueries, IServiceCommands commandsServices)
        {
            _serviceQueries = serviceQueries;
            _commandsServices = commandsServices;
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

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            CustomResponse customResponse = new CustomResponse();

            if (productRequest == null)
            {
                return customResponse.ClientErrorResponse();
            }

            var productCommands = new ProductCommands()
            {
                ProductName = productRequest.ProductName,
                ProductDescription = productRequest.ProductDescription,
                ProductPrice = productRequest.ProductPrice,
                ProductQuantity = productRequest.ProductQuantity,
                ProductProc = productRequest.ProductProc,
                ProductRam = productRequest.ProductRam,
                ProductStorage = productRequest.ProductStorage
            };

            var result = await _commandsServices.AddProduct(productCommands);

            if (result == null)
            {
                return customResponse.ClientErrorResponse();
            }

            if (result.ResultMessage == "Server Error")
            {
                return customResponse.ServerErrorResponse();
            }

            var response = new ProductResponse()
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                ProductPrice = result.ProductPrice,
                ProductQuantity = result.ProductQuantity,
                DateAdded = result.DateAdded,
                ProductProc = result.ProductProc,
                ProductRam = result.ProductRam,
                ProductStorage = result.ProductStorage
            };

            return Ok(response);
        }

        [Route("updateProduct/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest updateProductRequest)
        {
            CustomResponse customResponse = new CustomResponse();

            if (id != updateProductRequest.ProductId)
            {
                return customResponse.ClientErrorResponse();
            }

            var productCommands = new ProductCommands()
            {
                ProductId = id,
                ProductName = updateProductRequest.ProductName,
                ProductDescription = updateProductRequest.ProductDescription,
                ProductPrice = updateProductRequest.ProductPrice,
                ProductQuantity = updateProductRequest.ProductQuantity,
                ProductProc = updateProductRequest.ProductProc,
                ProductRam = updateProductRequest.ProductRam,
                ProductStorage = updateProductRequest.ProductStorage

            };

            var result = await _commandsServices.UpdateProduct(productCommands);

            if (result == null)
            {
                return customResponse.ClientErrorResponse();
            }

            if (result.ResultMessage == "Server Error")
            {
                return customResponse.ServerErrorResponse();
            }

            var response = new ProductResponse()
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                ProductPrice = result.ProductPrice,
                ProductQuantity = result.ProductQuantity,
                DateAdded = result.DateAdded,
                ProductProc = result.ProductProc,
                ProductRam = result.ProductRam,
                ProductStorage = result.ProductStorage
            };

            return Ok(response);
        }

        [Route("deleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = new ProductCommands();
            CustomResponse customResponse = new CustomResponse();

            if (id == null)
            {
                return customResponse.ClientErrorResponse();
            }

            Product.ProductId = id;

            var result = await _commandsServices.DeleteProduct(Product);

            if (result == null)
            {
                return customResponse.ClientErrorResponse();
            }

            if (result.ResultMessage == "Server Error")
            {
                return customResponse.ServerErrorResponse();
            }

            var response = new DeleteResponse()
            {
                ProductId = result.ProductId,
                Result = result.ResultMessage
            };

            return Ok(response);
        }
    }
}
