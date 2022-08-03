﻿using Ecommerce.EcommerceDTOs;
using Ecommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Ecommerce.Controllers
{
    [Route("products")]
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
                    DateAdded = DateTime.Now.ToString("MM/dd/yyyy")
                });
            }

            response.Products = result;
            return Ok(response);
        }

        [HttpPost]
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
                ProductQuantity = productRequest.ProductQuantity
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
                DateAdded = result.DateAdded
            };

            return Ok(response);
        }
    }
}
