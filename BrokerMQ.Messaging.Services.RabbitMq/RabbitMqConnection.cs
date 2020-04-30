﻿using System;
 using System.Reflection.Metadata;

 namespace BrokerMQ.Messaging.RabbitMq
{
    public class RabbitMqConnectionProperties
    {
        private string HostName { get; }
        internal string UserName { get; }
        internal string Password { get; }

        private RabbitMqConnectionProperties(string hostName, string userName, string password)
        {
            HostName = hostName;
            UserName = userName;
            Password = password;
        }

        public static RabbitMqConnectionProperties Create(string hostName, string userName, string password) =>
            new RabbitMqConnectionProperties(hostName, userName, password);

    }
}