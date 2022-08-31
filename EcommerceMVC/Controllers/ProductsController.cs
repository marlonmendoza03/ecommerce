using Ecommerce.EcommerceDTOs;
using EcommerceMVC.EcommerceDTOs;
using EcommerceMVC.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace EcommerceMVC.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IServiceQueries _serviceQueries;

        public ProductsController(IServiceCommands commandsServices, IServiceQueries serviceQueries)
        {
            _serviceQueries = serviceQueries;
        }

        [HttpGet("products")]
        public async Task<IActionResult> Products()
        {
            var products = await _serviceQueries.GetAllProducts();
            var response = new ProductsResponse();
            List<ProductsResponseDTO> result = new List<ProductsResponseDTO>();

            if (products == null)
            {
                return null;
            }

            foreach (var product in products)
            {
                result.Add(new ProductsResponseDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    ProductImage1 = product.ProductImage1,
                    ProductImage2 = product.ProductImage2,
                    ProductImage3 = product.ProductImage3,
                    DateAdded = DateTime.Now.ToString("MM/dd/yyyy"),
                    ProductProc = product.ProductProc,
                    ProductRam = product.ProductRam,
                    ProductStorage = product.ProductStorage
                });
            }

            response.Products = result;
            //return Ok(response);
            return View(response);
        }
    }
}