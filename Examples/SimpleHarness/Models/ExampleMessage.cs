using SimplyFi.MQ.Core.Contracts;

namespace SimpliFi.MQ.Harness.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}