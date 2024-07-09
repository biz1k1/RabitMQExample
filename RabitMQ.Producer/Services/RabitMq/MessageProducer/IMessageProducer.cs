namespace RabitMQ.Producer.Services.RabitMq.Producer
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
