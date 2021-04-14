using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ProductManagement.UI.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel( string name, decimal purchasePrice, decimal sellPrice, int ncm, string category, DateTime dataCadastro)
        {
            
            Name = name;
            PurchasePrice = purchasePrice;
            SellPrice = sellPrice;
            Ncm = ncm;
            Category.Name = category;
            DataCadastro = dataCadastro;
        }

        public ProductViewModel()
        {
            
        }

        [Key]
        public int Id { get; set; }
        
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        public int CategoryId { get; set; }
        
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(250, ErrorMessage = "O Campo Nome deve ter entre 2 e 250 Caracteres"), MinLength(2)]
        public string Name { get; set; }
        
        [DisplayName("Preço de Custo")]
        public decimal PurchasePrice { get; set; }
        
        [DisplayName("Preço de Venda")]
        public decimal SellPrice { get; set; }
        
        public int Ncm { get; set; }

        public IFormFile File { get; set; }
        public CategoryViewModel Category { get; set; } = new CategoryViewModel();
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        
        [DisplayName("Quantidade")]
        public int? Quantity { get; set; }
    }
}