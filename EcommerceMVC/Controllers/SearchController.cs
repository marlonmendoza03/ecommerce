using Ecommerce.EcommerceDTOs;
using Ecommerce.Exceptions;
using EcommerceMVC.EcommerceDTOs;
using EcommerceMVC.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace EcommerceMVC.Controllers
{
    [Route("/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchProductService _searchProductService;

        public SearchController(ISearchProductService searchProductService)
        {
            _searchProductService = searchProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductnameAndDescription(SearchRequestDTO searchRequestDTO)
        {
            var response = new List<ProductsResponseDTO>();
            CustomResponse customResponse = new CustomResponse();

            var searchRequest = new SearchProductDetails()
            {
                ProductName = searchRequestDTO.ProductName,
                ProductDescription = searchRequestDTO.ProductDescription
            };

            var result = await _searchProductService.SeachProductsService(searchRequest);

            if (result == null || searchRequest == null)
            {
                return customResponse.ClientErrorResponse();
            }

            foreach (var product in result)
            {
                response.Add(new ProductsResponseDTO()
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductId = product.ProductId,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    DateAdded = product.DateAdded
                });
            }
            return Ok(response);
        }
    }
}
