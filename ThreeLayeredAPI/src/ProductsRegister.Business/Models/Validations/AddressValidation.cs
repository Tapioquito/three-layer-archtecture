using FluentValidation;
using ProductsRegister.Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsRegister.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Street).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa estar entre{MinLenght} e {MaxLength} caracteres.");
            RuleFor(a => a.Nieghbourhood).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa estar entre{MinLenght} e {MaxLength} caracteres.");
            RuleFor(a => a.Complement).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa estar entre{MinLenght} e {MaxLength} caracteres.");
            RuleFor(a => a.Number).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa estar entre{MinLenght} e {MaxLength} caracteres.");
            RuleFor(a => a.ZipCode).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");
            RuleFor(a => a.City).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(a => a.State).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
