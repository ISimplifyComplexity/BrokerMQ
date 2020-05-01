using SimplyFi.MQ.Contracts;

namespace SimplyFi.MQ.Tests.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}