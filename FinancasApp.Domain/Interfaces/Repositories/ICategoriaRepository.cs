using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para os métodos de repositório de dados de categoria
    /// </summary>
    public interface ICategoriaRepository
    {
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        List<Categoria>? GetAll(Guid usuarioId);
        Categoria? GetById(Guid categoriaId, Guid usuarioId);
    }
}
