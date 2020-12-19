using Kanbersky.CleanArch.Core.Messaging.Abstract;
using Kanbersky.CleanArch.Core.Results.Exceptions.Concrete;
using RabbitMQ.Client;

namespace Kanbersky.CleanArch.Core.Messaging.Concrete
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            if (!IsConnected)
            {
                TryConnect();
            }
        }

        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw BaseException.BadRequestException("No RabbitMQ Connection!");
            }

            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _connection.Dispose();
        }

        public bool TryConnect()
        {
            _connection = _connectionFactory.CreateConnection();
            return IsConnected;
        }
    }
}
