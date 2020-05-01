using SimplyFi.MQ.Core.Contracts;

namespace SimplyFi.MQ.Harness.Models
{
    public class ExampleMessage : IMessage
    {
        public string Text { get; set; }
    }
}