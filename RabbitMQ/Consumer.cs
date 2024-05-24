// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Consumer
{
    public async Task GetMsg()
    {
        Console.WriteLine("GETMSG - awaiting...5seg");
        await Task.Delay(5000);

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "MENSAGERIA", durable: false, exclusive: false, autoDelete: false, arguments: null);
        
        Console.WriteLine("Aguardando msg...");

        var consumerMsg = new EventingBasicConsumer(channel);
        consumerMsg.Received += (model, ea) =>
        {
            var consumerMsg = ea.Body.ToArray();
            var decodMsg = Encoding.UTF8.GetString(consumerMsg);
            Console.WriteLine($"Mensagem recebida: {decodMsg}");
        };

        channel.BasicConsume(queue: "MENSAGERIA", autoAck: true, consumer: consumerMsg);

        Console.WriteLine("Aperte qualquer tecla para SAIR.");
        Console.ReadLine();
    }
}