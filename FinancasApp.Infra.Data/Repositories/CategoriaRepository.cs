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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public Categoria? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Categoria>().Find(id);
            }
        }

        public List<Categoria>? Get(Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Categoria>()
                    .Where(c => c.UsuarioId == usuarioId)
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }
    }
}
