using BrokerMQ.Contracts;
using BrokerMQ.Messaging;
using BrokerMQ.Messaging.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BrokerMQ.Tests
{
    public class Tests
    {
        private ServiceProvider serviceProvider { get; set; }

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMessageService, RabbitMqService>();
            services.AddTransient<IMessageBroker, MessageBroker>();
    
        }

        [Test]
        public void CanCreate()
        {
            var broker = serviceProvider.GetService<IMessageBroker>();
            
            Assert.NotNull(broker);
        }
    }
}