namespace BrokerMQ.Messaging.Contracts
{
    public interface IPublish
    {
        void Publish<TMessage>(string queueName, TMessage message) where TMessage : IMessage;
    }
}