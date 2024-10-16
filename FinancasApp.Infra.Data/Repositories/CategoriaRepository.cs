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
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Add(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(categoria);
                dataContext.SaveChanges();
            }
        }

        public void Update(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(categoria);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(categoria);
                dataContext.SaveChanges();
            }
        }

        public List<Categoria>? GetAll(Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Categoria>()
                    .Where(c => c.UsuarioId == usuarioId)
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Categoria? GetById(Guid categoriaId, Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Categoria>()
                    .Where(c => c.Id == categoriaId && c.UsuarioId == usuarioId)
                    .FirstOrDefault();
            }
        }
    }
}
