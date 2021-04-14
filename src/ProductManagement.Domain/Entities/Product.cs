using System;

namespace ProductManagement.Domain.Entities
{
    public class Product : Entity
    {
        public Product(int id, string name, decimal purchasePrice, decimal sellPrice, int ncm, string category, DateTime dataCadastro)
        {
            Id = id;
            Name = name;
            PurchasePrice = purchasePrice;
            SellPrice = sellPrice;
            Ncm = ncm;
            Category = new Category(category);
            DataCadastro = dataCadastro;
        }

        public Product()
        {
            
        }
        public string Name { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SellPrice { get; private set; }
        public int Ncm { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int? Quantity { get; private set; }
    }
}
