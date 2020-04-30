namespace BrokerMQ.Messaging.Contracts
{
    public interface IMessageService : IPublish, ISubscribe
    {
        void Connect();
     
    }
}
