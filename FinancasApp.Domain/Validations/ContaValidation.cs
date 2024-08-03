using FinancasApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Validations
{
    /// <summary>
    /// Classe para validação dos dados da conta
    /// </summary>
    public class ContaValidation : AbstractValidator<Conta>
    {
        public ContaValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O id da conta é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da conta é obrigatório.")
                .Length(6, 50).WithMessage("O nome da conta deve ter de 6 a 50 caracteres.");

            RuleFor(c => c.Valor)
                .NotNull().WithMessage("O valor da conta é obrigatório.")
                .GreaterThan(0).WithMessage("O valor da conta deve ser maior do que zero.");

            RuleFor(c => c.Data)
                .NotNull().WithMessage("A data da conta é obrigatória.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("A descrição da conta é obrigatória.")
                .Length(6, 250).WithMessage("A descrição da conta deve ter de 6 a 250 caracteres.");

            RuleFor(c => c.Tipo)
                .NotNull().WithMessage("O tipo da conta é obrigatório.");
        }
    }
}
