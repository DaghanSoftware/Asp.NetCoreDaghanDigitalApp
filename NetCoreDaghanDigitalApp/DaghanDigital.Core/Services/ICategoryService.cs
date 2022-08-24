﻿using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Models.Entities;
using DaghanDigital.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
