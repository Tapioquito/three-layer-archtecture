using ProductsRegister.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductsRegister.API.ViewModels
{
    public class SupplierViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} (CPF) e {1} (CNPJ) caracteres", MinimumLength = 11)]
        public string? Document { get; set; }
        public int SupplierType { get; set; }
        public bool isActive { get; set; }
        public AddressViewModel? Address { get; set; }

        public IEnumerable<ProductViewModel>? Products { get; set; }

    }
}
