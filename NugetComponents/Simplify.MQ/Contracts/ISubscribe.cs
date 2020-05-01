using System;
using System.Reflection;

namespace SimplyFi.MQ.Core.Contracts
{
    public interface ISubscribe
    {
        void Subscribe(object instance, MethodInfo methodInfo, Type modelType, string queueName);
    }
}