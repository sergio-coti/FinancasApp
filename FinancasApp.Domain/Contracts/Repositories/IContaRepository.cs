using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Repositories
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        List<Conta> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId);

        Conta? GetById(Guid id);
    }
}
