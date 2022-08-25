using DaghanDigital.Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaghanDigital.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductWithCategory();
    }
}
