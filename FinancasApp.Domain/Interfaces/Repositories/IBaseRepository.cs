using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica para os métodos comuns do repositório.
    /// </summary>
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetAll();

        TEntity? GetById(TKey id);
    }
}
