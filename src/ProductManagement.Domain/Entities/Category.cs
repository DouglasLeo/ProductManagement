using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Product { get; private set; }
    }
}