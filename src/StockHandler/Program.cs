// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
Console.WriteLine("Stock handler started");

var factory = new ConnectionFactory() { HostName = "localhost" ,Port=5672};
using(var connection = factory.CreateConnection())
using(var channel = connection.CreateModel())
{
    //channel.QueueDeclare(queue: "order-placed", durable: false, exclusive: false, autoDelete: false, arguments: null);

    Console.WriteLine(" [*] Waiting for order placed messages.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(" [x] Received {0}", message);
        //Thread.Sleep(5000);
    };

    channel.BasicConsume(queue: "order-placed", autoAck: true, consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
