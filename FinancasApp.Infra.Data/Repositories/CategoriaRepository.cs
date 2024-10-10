using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
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
            throw new NotImplementedException();
        }

        public void Update(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Delete(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public List<Categoria>? GetAll(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Categoria? GetById(Guid categoriaId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
