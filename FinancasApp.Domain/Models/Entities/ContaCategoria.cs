using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Models.Entities
{
    public class ContaCategoria
    {
        #region Propriedades

        public Guid? ContaId { get; set; }
        public Guid? CategoriaId { get; set; }

        #endregion

        #region Relacionamentos

        public Conta? Conta { get; set; }
        public Categoria? Categoria { get; set; }

        #endregion
    }
}
