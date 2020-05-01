using System;
using SimplyFi.MQ.Harness.Models;
using SimplyFi.MQ;
using SimplyFi.MQ.Connectors.RabbitMq;
using SimplyFi.MQ.Core;
using SimplyFi.MQ.Core.Contracts;
using SimplyFi.MQ.Core.Decorators;

namespace SimplyFi.MQ.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageBroker = new MessageBroker(
                new RabbitMqService(
                    new RabbitMqConnection(
                        "localhost", "user", "password")
                ));

            messageBroker.Publish("TestQueue", new ExampleMessage() { Text = "Bonjour! Daniel!" });
            Console.ReadLine();
        }
    }


    public class OrdersService : ISubscriber
    {
        [Subscribe(queueName: "TestQueue", typeof(ExampleMessage))]
        public void OrderWasCreated(ExampleMessage message)
        {
            Console.WriteLine("Orders service was called.");
            Console.WriteLine(message.Text);
        }
    }
}