using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para os métodos de repositório de dados de conta
    /// </summary>
    public interface IContaRepository
    {
        void Add(Conta conta);
        void Update(Conta conta);   
        void Delete(Conta conta);
        List<Conta> GetAll(Guid usuarioId, DateTime dataMin, DateTime dataMax);
        Conta? GetById(Guid contaId, Guid usuarioId);
    }
}
