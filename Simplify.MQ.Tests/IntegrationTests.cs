
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SimplyFi.MQ.Connectors.RabbitMq;
using SimplyFi.MQ.Contracts;
using SimplyFi.MQ.Tests.Models;

namespace SimplyFi.MQ.Tests
{
    public class Tests
    {
        private ServiceProvider ServiceProvider { get; set; }

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddTransient(_ =>
                new RabbitMqConnection("localhost", "user", "password"));

            services.AddTransient<IMessageService, RabbitMqService>();
            services.AddTransient<IMessageBroker, MessageBroker>();

            ServiceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void CanCreate()
        {
            var broker = ServiceProvider.GetService<IMessageBroker>();
            Assert.NotNull(broker);
        }

        [Test]
        public void CanPublish()
        {
            var broker = ServiceProvider.GetService<IMessageBroker>();
            broker.Publish("TestQueue", new ExampleMessage() { Text = "Hello Kiran" });
        }

        [Test]
        public void CanSubscribe()
        {
            var broker = ServiceProvider.GetService<IMessageBroker>();
        }
    }
}