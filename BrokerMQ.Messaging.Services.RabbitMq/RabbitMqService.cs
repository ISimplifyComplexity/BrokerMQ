using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using BrokerMQ.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BrokerMQ.Messaging.RabbitMq
{
    public class RabbitMqService : IDisposable, IMessageService
    {
        private readonly IBusConnectionProperties _connProperties;

        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqService(IBusConnectionProperties connProperties)
        {
            _connProperties = connProperties;
        }

        public void Connect()
        {
            if (_connection != null) return;

            _factory = new ConnectionFactory()
            {
                HostName = _connProperties.HostName,
                UserName = _connProperties.UserName,
                Password = _connProperties.Password
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Dispose()
        {
            _factory = null;

            _connection.Close();
            _channel.Close();

            _connection.Dispose();
            _channel.Dispose();

            _connection = null;
            _channel = null;
        }

        public void Publish<TMessage>(string queueName, TMessage message) where TMessage : IMessage
        {
            CreateQueue(queueName);
            
            var body = JsonSerializer.SerializeToUtf8Bytes(message);

            _channel.BasicPublish(exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }

        private void CreateQueue(string queueName)
        {
            _channel.QueueDeclare(queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }


        public void Subscribe(object instance, MethodInfo methodInfo, Type modelType, string queueName)
        {
            CreateQueue(queueName);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                var messageModel = JsonSerializer
                        .Deserialize(message, modelType)
                    as IMessage;
                
                methodInfo.Invoke(instance, parameters: new object[] {messageModel});
            };

            _channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);
        }
    }
}