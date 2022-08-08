using EcommerceMVC.EcommerceDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EcommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceCommands _commandsServices;
        private readonly IServiceQueries _serviceQueries;

        public HomeController(IServiceCommands commandsServices, IServiceQueries serviceQueries)
        {
            _commandsServices = commandsServices;
            _serviceQueries = serviceQueries;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new ProductsResponse();
            var allProducts = await _serviceQueries.GetAllProducts();
            var logsResponse = new List<ProductsResponseDTO>();
            if (allProducts == null)
            {
                return null;
            }

            foreach (var products in allProducts)
            {
                logsResponse.Add(new ProductsResponseDTO()
                {
                    ProductId = products.ProductId,
                    ProductName = products.ProductName,
                    ProductDescription = products.ProductDescription,
                    ProductPrice = products.ProductPrice,
                    ProductImage1 = products.ProductImage1,
                    IsFeatured = products.IsFeatured
                });
            }
            response.Products = logsResponse;
            return View(response);
        }
    }
}
