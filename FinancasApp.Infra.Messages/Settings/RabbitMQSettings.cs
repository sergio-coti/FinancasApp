using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para configuração dos parametros de acesso
    /// ao servidor da mensageria do RabbitMQ
    /// </summary>
    public class RabbitMQSettings
    {
        public static string Host => "localhost";
        public static int Port => 5672;
        public static string User => "guest";
        public static string Pass => "guest";
        public static string Queue => "logs_financas";
    }
}
