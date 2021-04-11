using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public int Ncm { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}
