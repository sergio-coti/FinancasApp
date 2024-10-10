using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para os métodos de repositório de dados de usuário
    /// </summary>
    public interface IUsuarioRepository
    {
        //Método para gravar um usuário no banco de dados
        void Add(Usuario usuario);

        //Método para verificar se um email já está cadastrado no banco de dados
        bool VerifyExists(string email);

        //Método para consultar 1 usuário através do email e da senha
        Usuario? Get(string email, string senha);
    }
}
