using RabbitMQ.Client;

namespace RabitMQConsumer
{
    public class RabbitMqConnection : IDisposable
    {
        private IConnection? _connection;
        public IConnection Connection => _connection!;
        public IModel InitializeConnection(string HostName)
        {
            var factory = new ConnectionFactory()
            {
                HostName =HostName,
            };
            _connection = factory.CreateConnection();
            return _connection.CreateModel();
        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
