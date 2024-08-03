using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade de dominio
    /// </summary>
    public class Conta
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public TipoConta? Tipo { get; set; }
    }
}
