using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Logs.Settings
{
    /// <summary>
    /// Classe para mapearmos os parâmetros de conexão com o MongoDB
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Endereço do servidor para conexão com o banco de dados
        /// </summary>
        public static string Uri => "mongodb://localhost:27017/";

        /// <summary>
        /// Nome do banco de dados que iremos acessar
        /// </summary>
        public static string Database => "BDAuditoria";
    }
}
