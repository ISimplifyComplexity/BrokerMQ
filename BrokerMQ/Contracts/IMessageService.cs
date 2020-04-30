namespace BrokerMQ.Contracts
{
    public interface IMessageService : IPublish, ISubscribe
    {
        void Connect();
     
    }
}
