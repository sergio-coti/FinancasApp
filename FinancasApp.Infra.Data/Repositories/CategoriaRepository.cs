using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para a entidade Categoria
    /// </summary>
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {

    }
}
