using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public class ContaRepository : BaseRepository<Conta, Guid>, IContaRepository
    {
        public List<Conta> Get(DateTime dataMin, DateTime dataMax)
        {
            using (var context = new DataContext())
            {
                return context.Set<Conta>()
                    .Where(c => c.Data >= dataMin && c.Data <= dataMax)
                    .OrderByDescending(c => c.Data)
                    .ToList();
            }
        }
    }
}
