using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Domain.Services
{
    public class ProfitMarginService : IProfitMarginService
    {
        public decimal ProfitMargin(Product product)
        {
            var profit = product.SellPrice - product.PurchasePrice;
            return (profit / product.SellPrice) * 100;
        }
        
        
    }
}