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
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public List<Conta> GetByDatas(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Conta>()
                    .Where(c => c.Data >= dataMin && c.Data <= dataMax)
                    .OrderBy(c => c.Data)
                    .ToList();
            }
        }

        public Conta? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Conta>().Find(id);
            }
        }

        public List<Conta> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Conta>()
                    .Where(c => c.Data >= dataMin
                             && c.Data <= dataMax
                             && c.UsuarioId == usuarioId)
                    .OrderByDescending(c => c.Data)
                    .ToList();
            }
        }
    }
}
