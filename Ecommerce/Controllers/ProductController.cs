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
        private readonly IServiceCommands _commandsServices;
        private readonly IServiceQueries _serviceQueries;

        public ProductController(IServiceCommands commandsServices, IServiceQueries serviceQueries)
        {
            _commandsServices = commandsServices;
            _serviceQueries = serviceQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = new GetAllProducts();
            var products = await _serviceQueries.GetAllProducts();
            var res = new List<GetAllProductsDTO>();
            if (products == null)
            {
                return null;
            }

            foreach (var product in products)
            {
                res.Add(new GetAllProductsDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    DateAdded = product.DateAdded
                });
            }

            response.Products = res;
            return Ok(response);
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
