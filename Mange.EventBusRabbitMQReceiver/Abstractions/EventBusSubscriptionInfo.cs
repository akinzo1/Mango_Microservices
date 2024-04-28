using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Mango.EventBus.Abstractions;


public class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];

    public JsonSerializerOptions JsonSerializerOptions { get; } = new(DefaultSerializerOptions);

    internal static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        TypeInfoResolver = JsonSerializer.IsReflectionEnabledByDefault ? CreateDefaultTypeResolver() : JsonTypeInfoResolver.Combine()
    };

    private static IJsonTypeInfoResolver CreateDefaultTypeResolver()
        => new DefaultJsonTypeInfoResolver();

}






//// See http
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Reflection.PortableExecutable;
//using System.Text;
//using System.Xml.Serialization;

//ConnectionFactory factory = new();
//factory.Uri = new System.Uri("amqp://guest:guest@localhost:5672");
//factory.ClientProvidedName = "Rabbit Receiver App";

//IConnection cnn = factory.CreateConnection();

//IModel channel = cnn.CreateModel();

//string exchangeName = "DemoExchange";

//string routingKey = "demo-routing-key";

//string queueName = "demoqueue3";

//channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
//channel.QueueDeclare(queueName, false, false, false, null);
//channel.QueueBind(queueName, exchangeName, routingKey, null);

//channel.BasicQos(0, 1, false);
//var consumer = new EventingBasicConsumer(channel);

//consumer.Received += (sender, args) =>
//{
//    var mBody = args.Body.ToArray();
//    string message = Encoding.UTF8.GetString(mBody);
//    Console.WriteLine($"{message}");
//    channel.BasicAck(args.DeliveryTag, false);

//};

//channel.Close();
//cnn.Close();


