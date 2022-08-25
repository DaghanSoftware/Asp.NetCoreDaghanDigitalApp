using DaghanDigital.Core.Models.Entities;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
