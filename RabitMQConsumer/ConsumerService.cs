using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabitMQConsumer
{
    public class ConsumerService
    {
        private RabbitMqConnection _rabbitMqConnection;
        public ConsumerService(RabbitMqConnection rabbitMqConnection)
        {
            _rabbitMqConnection=rabbitMqConnection;
        }
        public void ConsumerListener(string HostName,string queue)
        {
            using (var channel =_rabbitMqConnection.InitializeConnection(HostName))
            {
                channel.QueueDeclare(queue: queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: false,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
