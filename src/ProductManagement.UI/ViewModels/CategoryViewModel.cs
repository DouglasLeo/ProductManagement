using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProductManagement.Domain.Entities;

namespace ProductManagement.UI.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres"), MinLength(2)]
        public string Name { get; set; }
        
        public ICollection<ProductViewModel> Product { get; set; }
    }
}