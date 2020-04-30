using System;
using BrokerMQ;
using BrokerMQ.Contracts;
using BrokerMQ.Decorators;
using BrokerMQ.RabbitMq;
using harness.Models;


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

            messageBroker.Publish("TestQueue", new ExampleMessage() {Text = "Bonjour! Daniel!"});
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