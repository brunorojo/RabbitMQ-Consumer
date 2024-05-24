// See https://aka.ms/new-console-template for more information
using RabbitMQ;
using RabbitMQ.Client;
using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        new Publisher().SendMsg();
        //new Consumer().GetMsg();

        
    }
}