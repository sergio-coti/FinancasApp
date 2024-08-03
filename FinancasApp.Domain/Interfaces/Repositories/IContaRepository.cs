using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface específica para repositório de contas
    /// </summary>
    public interface IContaRepository : IBaseRepository<Conta, Guid>
    {
        List<Conta> Get(DateTime dataMin, DateTime dataMax);
    }
}
