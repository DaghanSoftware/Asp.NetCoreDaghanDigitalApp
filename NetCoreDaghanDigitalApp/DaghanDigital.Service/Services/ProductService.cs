using AutoMapper;
using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Models.Entities;
using DaghanDigital.Core.Repositories;
using DaghanDigital.Core.Services;
using DaghanDigital.Core.UnitOfWorks;
using DaghanDigital.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaghanDigital.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            var product = await _productRepository.GetProductWithCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productDto); 
        }
        //public async Task<List<ProductWithCategoryDto>> GetProductWithCategory()
        //{
        //    var product = await _productRepository.GetProductWithCategory();
        //    var productDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
        //    return productDto;
        //}
    }
}
