using System;
using System.Reflection;

namespace BrokerMQ.Messaging.Contracts
{
    public interface ISubscribe
    {
        void Subscribe(object instance, MethodInfo methodInfo, Type modelType, string queueName);
    }
}