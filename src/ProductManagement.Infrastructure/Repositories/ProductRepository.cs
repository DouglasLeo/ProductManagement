using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Domain.Services;
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
            return await DbSet.Where(q => q.Quantity < quantity).ToListAsync();
        }

        public async Task<List<Product>> FindByProfitMargin(decimal percentage)
        {
            return await (from product in DbSet 
                let profitMargin = _profitMarginService.ProfitMargin(product) 
                where profitMargin > percentage 
                select product).ToListAsync();
        }
    }
}