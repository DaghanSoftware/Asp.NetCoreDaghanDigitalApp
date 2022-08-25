namespace DaghanDigital.Core.Models.DTOs
{
    public class ProductDto : BaseDto
    {
        public string? ProductName { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
