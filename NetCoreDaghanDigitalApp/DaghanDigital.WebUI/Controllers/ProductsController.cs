﻿using AutoMapper;
using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Models.Entities;
using DaghanDigital.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DaghanDigital.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService service, ICategoryService categoryService, IMapper mapper)
        {
            _service = service;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProductWithCategory());
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");

            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName");
            return View();

        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _service.GetByIdAsync(id);

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName",product.CategoryId);

            return View(_mapper.Map<ProductDto>(product));


        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "CategoryName", productDto.CategoryId);
            return View(productDto);


        }
    }
}
