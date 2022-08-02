using Ecommerce.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Ecommerce.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandsServices _commandsServices;

        public ProductController(ICommandsServices commandsServices)
        {
            _commandsServices = commandsServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            var productCommands = new ProductCommands()
            {
                ProductName = productRequest.ProductName,
                ProductDescription = productRequest.ProductDescription,
                ProductPrice = productRequest.ProductPrice,
                ProductQuantity = productRequest.ProductQuantity
            };

            var result = await _commandsServices.AddProduct(productCommands);

            var response = new ProductResponse()
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                ProductPrice = result.ProductPrice,
                ProductQuantity = result.ProductQuantity,
                DateAdded = DateTime.Today
            };

            return Ok(response);
        }
    }
}
