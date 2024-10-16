using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Security.Settings
{
    public class JwtTokenSettings
    {
        /// <summary>
        /// Chave secreta para criptografia do token
        /// </summary>
        public static string SecretKey => "32EEBE77-9268-46DD-A053-61FAF6A21456";

        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public static int ExpirationInHours => 1;
    }
}
