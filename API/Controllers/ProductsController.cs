using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> getProducts()
        {
            var products= await _repository.getProductsAsync();
            return Ok(products); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int Id)
        {
            return await  _repository.GetProductAsync(Id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductBrands()
        {
            return Ok(await _repository.getProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getProductTypes()
        {
            return Ok(await _repository.GetProductTypesAsync());
        }
    }
}