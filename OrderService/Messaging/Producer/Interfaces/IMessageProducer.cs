namespace OrderService.Messaging.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
