using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using core.Interface;
using core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IGenericRespository<product> _productsRepo;
        private readonly IGenericRespository<ProductBrand> _productBrandRepo;
        private readonly IGenericRespository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRespository<product> productsRepo,
        IGenericRespository<ProductBrand> ProductBrandRepo, IGenericRespository<ProductType> productTypeRepo
        , IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _productBrandRepo = ProductBrandRepo;
            _productTypeRepo = productTypeRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> Getproducts()
        {
            var spec = new ProductsWithTypesandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<product> , IReadOnlyList<ProductToReturnDto>>
            (products));
;        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> Getproduct(int id)
        {
            var spec = new ProductsWithTypesandsSpecification(id);

            var product = await _productsRepo.GetEntitywithspec(spec);

            return _mapper.Map<product ,ProductToReturnDto>(product);

        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetproductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}