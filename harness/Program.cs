using System;
using BrokerMQ.Messaging;
using BrokerMQ.Messaging.Contracts;
using BrokerMQ.Messaging.Decorators;
using BrokerMQ.Messaging.RabbitMq;
using BrokerMQ.Tests.Models;

namespace harness
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

            // messageBroker.Publish("TestQueue", new ExampleMessage() {Text = "Bonjour!"});
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