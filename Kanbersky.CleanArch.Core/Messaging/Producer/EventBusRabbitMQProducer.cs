using Kanbersky.CleanArch.Core.Messaging.Abstract;
using Kanbersky.CleanArch.Core.Messaging.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Kanbersky.CleanArch.Core.Messaging.Producer
{
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMQConnection _connection;

        public EventBusRabbitMQProducer(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void PublishBasketCheckout(string queueName, ShoppingCartCheckoutEvent checkoutEvent)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(checkoutEvent);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2; // Teslimat modunu persistent olarak set ettik.

                channel.ConfirmSelect();
                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true, basicProperties: properties, body: body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sending Event");
                };

                channel.ConfirmSelect();
            }
        }
    }
}
