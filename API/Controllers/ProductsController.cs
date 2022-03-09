using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _productTypesRepository;
        private readonly IGenericRepository<ProductBrand> _productBradRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
                 IGenericRepository<ProductBrand> productBradRepository,
                IGenericRepository<ProductType> productTypesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBradRepository = productBradRepository;
            _productTypesRepository = productTypesRepository;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> getProducts()
        {
            var spec = new ProductsWithTypesandBrandsSpecification();
            var products = await _productRepository.ListAsync(spec);
            return Ok(_mapper
                .Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> getProduct(int Id)
        {
            var spec = new ProductsWithTypesandBrandsSpecification(Id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product,ProductToReturnDTO>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductBrands()
        {
            return Ok(await _productBradRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getProductTypes()
        {
            return Ok(await _productTypesRepository.ListAllAsync());
        }
    }
}