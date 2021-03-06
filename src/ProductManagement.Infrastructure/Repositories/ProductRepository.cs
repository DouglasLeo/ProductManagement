using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infrastructure.Context;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IProfitMarginService _profitMarginService;
        public ProductRepository(ProductManagementContext context, IProfitMarginService profitMarginService) : base(context)
        {
            _profitMarginService = profitMarginService;
        }
        public async Task<List<Product>> FindByStock(int quantity)
        {
            return await Context.Products.AsNoTracking().Where(q => q.Quantity < quantity).ToListAsync();
        }

        public async Task<List<Product>> FindByProfitMargin(decimal percentage)
        {
            return await (from product in Context.Products.AsNoTracking() 
                let profitMargin = _profitMarginService.ProfitMargin(product) 
                where profitMargin > percentage 
                select product).ToListAsync();
        }

        public async Task<Product> FindProductCategory(int id)
        {
            return await Context.Products.AsNoTracking()
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}