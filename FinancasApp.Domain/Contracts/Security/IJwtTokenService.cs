using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Security
{
    /// <summary>
    /// Interface para definirmos os métodos de infraestrutura
    /// de autenticação do projeto através do JWT
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Método para gerarmos o TOKEN JWT do usuário
        /// </summary>
        string GetJwtToken(Usuario usuario);
    }
}
