﻿using RabbitMQ.Client;

namespace RabitMQ.Producer.Services.RabitMq.Connection
{
    public class RabbitMqConnection : IRabbitMqConnection, IDisposable  
    {
        private  IConnection? _connection;
        public IConnection Connection  => _connection!;
        public RabbitMqConnection()
        {
            InitializeConnection();
        }
        private void InitializeConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync=true,
            };

            _connection = factory.CreateConnection();

        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
