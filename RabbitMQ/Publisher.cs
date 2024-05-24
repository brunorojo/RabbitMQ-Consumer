using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using RabbitMQ.Client;

namespace RabbitMQ
{


    internal class Publisher
    {

        public async Task SendMsg()
        {
            Console.WriteLine("SENDMSG - awaiting...5seg");
            await Task.Delay(5000); 

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "MENSAGERIA", durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine("Digite sua msg e pressione <ENTER>. Para SAIR pressione <ENTER> 2x");

            while (true)
            {
                string msg = Console.ReadLine();
                Console.Clear();

                if (msg == "" || msg == null)
                {
                    break;
                }

                //Encoda e envia para a fila
                var encodMsg = Encoding.UTF8.GetBytes(msg);
                channel.BasicPublish(exchange: string.Empty, routingKey: "MENSAGERIA", basicProperties: null, body: encodMsg);

                Console.WriteLine($"[X] Última msg enviada: {msg}");
                Console.WriteLine("Digite sua msg e pressione <ENTER>");

            }

        }


    }

}
