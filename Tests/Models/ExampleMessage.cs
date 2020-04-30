using BrokerMQ.Contracts;

namespace BrokerMQ.Tests.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}