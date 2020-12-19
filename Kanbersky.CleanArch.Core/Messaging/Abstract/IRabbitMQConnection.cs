using RabbitMQ.Client;
using System;

namespace Kanbersky.CleanArch.Core.Messaging.Abstract
{
    public interface IRabbitMQConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
