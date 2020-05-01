namespace SimplyFi.MQ.Contracts
{
    public interface IPublish
    {
        void Publish<TMessage>(string queueName, TMessage message) where TMessage : IMessage;
    }
}