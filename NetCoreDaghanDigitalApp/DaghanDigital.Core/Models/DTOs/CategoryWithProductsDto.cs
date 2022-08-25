using System.Collections.Generic;

namespace DaghanDigital.Core.Models.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
