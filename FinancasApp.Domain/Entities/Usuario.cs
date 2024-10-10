using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Entities
{
    /// <summary>
    /// Modelo de dados para entidade Usuario
    /// </summary>
    public class Usuario
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        #endregion

        #region Relacionamentos

        public List<Categoria>? Categorias { get; set; }
        public List<Conta>? Contas { get; set; }

        #endregion
    }
}
