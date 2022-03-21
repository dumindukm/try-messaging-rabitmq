// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
Console.WriteLine("Payment handler started");

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
        Console.WriteLine("Payment handler : [x] Received {0}", message);
    };

    channel.BasicConsume(queue: "order-placed", autoAck: true, consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
