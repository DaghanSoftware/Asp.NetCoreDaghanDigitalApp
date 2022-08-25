using DaghanDigital.Core.Models.DTOs;
using DaghanDigital.Core.Utilities.Results;

namespace DaghanDigital.WebUI.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("product/GetProductWithCategory");
            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto newproduct)
        {
            var response = await _httpClient.PostAsJsonAsync("product", newproduct);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"product/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto newproduct)
        {
            var response = await _httpClient.PutAsJsonAsync("product", newproduct);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
