using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProfitMarginService
    {
        decimal ProfitMargin(Product product);
    }
}