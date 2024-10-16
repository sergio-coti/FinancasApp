using FinancasApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Requests
{
    public class ContaRequestDto
    {
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public int? Tipo { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
