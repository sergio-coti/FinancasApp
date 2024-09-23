using FinancasApp.Domain.Contracts.Repositories;
using FinancasApp.Domain.Models.Entities;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public class ContaCategoriaRepository : BaseRepository<ContaCategoria>, IContaCategoriaRepository
    {
        public ContaCategoria? Get(Guid contaId, Guid categoriaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ContaCategoria>()
                    .FirstOrDefault(c => c.ContaId == contaId
                                      && c.CategoriaId == categoriaId);
            }
        }
    }
}
