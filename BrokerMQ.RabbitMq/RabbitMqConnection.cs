namespace BrokerMQ.RabbitMq
{
    public class RabbitMqConnection
    {
        public string HostName { get; }
        public string UserName { get; }
        public string Password { get; }

        public RabbitMqConnection(string hostName, string userName, string password)
        {
            HostName = hostName;
            UserName = userName;
            Password = password;
        }
    }
}