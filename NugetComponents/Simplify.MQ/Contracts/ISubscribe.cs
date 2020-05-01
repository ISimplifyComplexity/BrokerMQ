using System;
using System.Reflection;

namespace SimplyFi.MQ.Contracts
{
    public interface ISubscribe
    {
        void Subscribe(object instance, MethodInfo methodInfo, Type modelType, string queueName);
    }
}