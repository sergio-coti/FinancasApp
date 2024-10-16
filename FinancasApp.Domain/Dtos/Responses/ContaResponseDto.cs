using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos.Responses
{
    public class ContaResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public int? Tipo { get; set; }
        public CategoriaResponseDto? Categoria { get; set; }
    }
}
