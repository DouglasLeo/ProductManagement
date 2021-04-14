using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public ICollection<Product> Product { get; private set; }
    }
}