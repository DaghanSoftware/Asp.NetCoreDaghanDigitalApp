using AutoMapper;
using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Models.Entities;
using DaghanDigital.Core.Services;
using DaghanDigital.Core.Utilities.Results;
using DaghanDigital.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaghanDigital.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productService.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var product = await _productService.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(product.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productdto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productdto));
            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productdto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productdto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
             await _productService.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
