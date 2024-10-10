using FinancasApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Entities
{
    /// <summary>
    /// Modelo de dados para entidade Conta
    /// </summary>
    public class Conta
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public TipoConta? Tipo { get; set; }
        public Guid? CategoriaId { get; set; }
        public Guid? UsuarioId { get; set; }

        #endregion

        #region Relacionamentos

        public Categoria? Categoria { get; set; }
        public Usuario? Usuario { get; set; }

        #endregion
    }
}
