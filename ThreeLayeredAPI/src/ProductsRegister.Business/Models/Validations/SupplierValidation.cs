using FluentValidation;
using ProductsRegister.Business.Models;
using static ProductsRegister.Business.Models.Validations.Documents.ValidationDocs;

namespace ProductsRegister.Business.Models.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa estar entre{MinLenght} e {MaxLength} caracteres.");
            When(s => s.SupplierType == SupplierType.NaturalPerson, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(s => CpfValidacao.Validar(s.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
            When(s => s.SupplierType == SupplierType.BusinessEntity, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(s => CnpjValidacao.Validar(s.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
