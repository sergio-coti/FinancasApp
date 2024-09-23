using FinancasApp.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Messages.Contexts
{
    /// <summary>
    /// Classe para conexão com o servidor da mensageria
    /// </summary>
    public class RabbitMQContext
    {
        /// <summary>
        /// Método para retornar uma conexão com o servidor da mensageria
        /// </summary>
        public IModel? CreateConnection()
        {
            //acessando o servidor da mensageria
            var connectionFactory = new ConnectionFactory()
            {
                HostName = RabbitMQSettings.Host,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.User,
                Password = RabbitMQSettings.Pass
            };

            //abrindo conexão com o servidor
            using (var connection = connectionFactory.CreateConnection())
            {
                //criando / acessando a fila
                using (var model = connection.CreateModel())
                {
                    model.QueueDeclare(
                        queue: RabbitMQSettings.Queue,
                        durable: true,
                        autoDelete: false,
                        exclusive: false,
                        arguments: null
                        );

                    //retornando a configuração
                    return model;
                }                
            }
        }
    }
}
