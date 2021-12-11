using Microsoft.AspNetCore.Mvc;
using PostgresEF.Dtos;
using PostgresEF.Interfaces;
using PostgresEF.Models;
using PostgresEF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetProducts()
        {
            var products = await _productRepository.GetAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IProduct>> GetProduct(int id)
        {
            var product = await _productRepository.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                DateCreated = DateTime.Now
            };

            await _productRepository.Add(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody]UpdateProductDto updateProductDto)
        {
            var product = new Product
            {
                ID = id,
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price
            };

            await _productRepository.Update(product);
            return Ok();
        }
    }
}
