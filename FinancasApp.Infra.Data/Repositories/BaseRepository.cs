using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Remove
                    (entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity? GetById(TKey id)
        {
            using (var context = new DataContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}
