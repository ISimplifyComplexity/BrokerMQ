namespace SimplyFi.MQ.Core.Contracts
{
    public interface IMessageService : IPublish, ISubscribe
    {
        void Connect();
     
    }
}
