using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
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
            throw new NotImplementedException();
        }

        public void Update(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Delete(Conta conta)
        {
            throw new NotImplementedException();
        }

        public List<Conta> GetAll(Guid usuarioId, DateTime dataMin, DateTime dataMax)
        {
            throw new NotImplementedException();
        }

        public Conta? GetById(Guid contaId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
