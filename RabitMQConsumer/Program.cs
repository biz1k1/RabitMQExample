using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabitMQConsumer;
using System.Text;

class Program
{
    static void Main()
    {
        ConsumerService consumerService = new ConsumerService(new RabbitMqConnection());
        consumerService.ConsumerListener("localhost","message");
    }
}