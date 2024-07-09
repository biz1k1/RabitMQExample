using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using RabitMQ.Producer.Services.RabitMq.Connection;
using System.Text;
using System.Text.Json;

namespace RabitMQ.Producer.Services.RabitMq.Producer
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;
        public MessageProducer(IRabbitMqConnection connection)
            {
                _connection = connection;
            }
            public void SendMessage<T>(T message)
            {
                using var channel = _connection.Connection.CreateModel();
                channel.QueueDeclare(queue: "message",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null); ;

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "api.events",
                                     routingKey: "api.post.message",
                                     basicProperties: properties,
                                     body: body);
            }
        }
    }

