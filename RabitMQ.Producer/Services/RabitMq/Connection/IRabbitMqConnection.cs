using RabbitMQ.Client;

namespace RabitMQ.Producer.Services.RabitMq.Connection
{
    public interface IRabbitMqConnection
    {
        IConnection Connection { get; }
    }
}
