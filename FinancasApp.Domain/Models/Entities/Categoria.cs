using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Models.Entities
{
    public class Categoria
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public Guid? UsuarioId { get; set; }

        #endregion

        #region Relacionamentos

        public List<ContaCategoria>? ContaCategoria { get; set; }
        public Usuario? Usuario { get; set; }

        #endregion
    }
}
