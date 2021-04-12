using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> FindByStock(int quantity);
        Task<List<Product>> FindByProfitMargin(decimal percentage);
        Task<Product> FindProductCategory(int id);
    }
}