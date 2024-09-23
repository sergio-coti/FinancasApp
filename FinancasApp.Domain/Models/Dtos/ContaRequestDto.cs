using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Models.Dtos
{
    public class ContaRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe o nome da conta.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data da conta.")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor da conta.")]
        public decimal? Valor { get; set; }

        [Range(1,2, ErrorMessage = "Por favor, informe (1) RECEBER ou (2) PAGAR.")]
        [Required(ErrorMessage = "Por favor, informe o tipo da conta.")]
        public int? Tipo { get; set; }
    }
}
