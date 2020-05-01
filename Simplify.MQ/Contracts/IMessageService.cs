namespace SimplyFi.MQ.Contracts
{
    public interface IMessageService : IPublish, ISubscribe
    {
        void Connect();
     
    }
}
