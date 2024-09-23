using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Security.Settings
{
    /// <summary>
    /// Classe para configurarmos os parametros 
    /// para geração dos TOKENS JWT
    /// </summary>
    public class JwtTokenSettings
    {
        /// <summary>
        /// Chave secreta utilizada para criptografar e assinar o TOKEN
        /// </summary>
        public static string SecretKey => "25E64B3D-8152-486E-81AD-E08C5BF58CB7";

        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public static int ExpirationInHours => 1;
    }
}
