using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.UI.ViewModels
{
    public class ProductViewModel
    {
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
        
        [MaxLength(8)]
        public int Ncm { get; set; }

        public CategoryViewModel Category { get;  set; }
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        
        [DisplayName("Quantidade")]
        public int? Quantity { get; set; }
    }
}