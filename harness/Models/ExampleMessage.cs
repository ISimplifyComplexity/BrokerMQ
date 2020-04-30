using BrokerMQ.Contracts;

namespace harness.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}