// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using OrderCreator.Services.concrete;
using OrderCreator.Services.interfaces;
using RabbitMQ.Client;

Console.WriteLine("Order creation process started");
IOrderService orderService = new OrderService();
// var order = orderService.GetOrder(1);

var factory = new ConnectionFactory() { HostName = "localhost" , Port=5672 };
using(var connection = factory.CreateConnection())
using(var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange:"middleware",
                         type:"direct");

    channel.QueueDeclare(queue: "order-placed",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
    channel.QueueBind(exchange:"middleware",queue:"order-placed", routingKey:"order_init");

    for(int i=0; i<10;i++)
    {
        var order = orderService.GetOrder(Guid.NewGuid());
        var orderSerialized = JsonSerializer.Serialize(order);


        channel.BasicPublish(exchange: "middleware",
                                routingKey: "order_init",
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(orderSerialized)
                                );
        Console.WriteLine(" [x] Sent {0}", order.Id);
    }


    
}

Console.WriteLine("Execution finished");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();


