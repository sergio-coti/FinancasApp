using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Repositories
{
    public interface IContaCategoriaRepository : IBaseRepository<ContaCategoria>
    {
        ContaCategoria? Get(Guid contaId, Guid categoriaId);
    }
}
