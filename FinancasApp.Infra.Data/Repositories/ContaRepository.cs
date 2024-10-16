using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        public void Add(Conta conta)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(conta);
                dataContext.SaveChanges();
            }
        }

        public void Update(Conta conta)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(conta);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Conta conta)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(conta);
                dataContext.SaveChanges();
            }
        }

        public List<Conta> GetAll(Guid usuarioId, DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Conta>()
                    .Include(c => c.Categoria)
                    .Where(c => c.UsuarioId == usuarioId && c.Data >= dataMin && c.Data <= dataMax)
                    .OrderBy(c => c.Data)
                    .ToList();
            }
        }

        public Conta? GetById(Guid contaId, Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Conta>()
                    .Include(c => c.Categoria)
                    .Where(c => c.Id == contaId && c.UsuarioId == usuarioId)
                    .FirstOrDefault();
            }
        }
    }
}
