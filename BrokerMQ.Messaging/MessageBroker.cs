using System;
using System.Linq;
using System.Reflection;
using BrokerMQ.Contracts;
using BrokerMQ.Messaging.Decorators;
using BrokerMQ.Messaging.Messages;

namespace BrokerMQ.Messaging
{
    public class MessageBroker : IMessageBroker
    {
        private readonly IMessageService _service;

        public MessageBroker(IMessageService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service), "Message queue service should not be null");

            _service.Connect();

            var assembly = Assembly.GetCallingAssembly();

            assembly.GetTypes().ToList().ForEach(asmType =>
            {
                asmType.GetMethods().ToList().ForEach(methodInfo =>
                {
                    methodInfo.CustomAttributes
                        .Where(attributeData => attributeData.AttributeType == typeof(SubscribeAttribute))
                        .ToList()
                        .ForEach(subscriber =>
                        {
                            var queueName = subscriber.ConstructorArguments[0].Value as string;
                            var messageType = subscriber.ConstructorArguments[1].Value as Type;
                            var instance = Activator.CreateInstance(asmType);
                            _service.Subscribe(instance, methodInfo, messageType, queueName);
                        });
                });
            });
        }

        public void Publish<TMessage>(string queueName, TMessage message) where TMessage : IMessage
        {
            _service.Publish("orders", new ExampleMessage() { Text = "Hello World" });
        }
    }


}
