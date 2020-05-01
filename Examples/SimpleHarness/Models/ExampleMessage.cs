using SimplyFi.MQ.Contracts;

namespace SimpliFi.MQ.Harness.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}