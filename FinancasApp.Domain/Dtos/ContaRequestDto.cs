using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Dtos
{
    /// <summary>
    /// Objeto para entrada de dados de conta
    /// </summary>
    public class ContaRequestDto
    {
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public int? Tipo { get; set; }
    }
}
