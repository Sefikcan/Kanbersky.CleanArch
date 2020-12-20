using AutoMapper;
using Kanbersky.CleanArch.Core.Constants;
using Kanbersky.CleanArch.Core.Messaging.Abstract;
using Kanbersky.CleanArch.Core.Messaging.Events;
using Kanbersky.CleanArch.Core.Repositories.Abstract.EntityFramework;
using Kanbersky.CleanArch.Order.Services.Commands;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanbersky.CleanArch.Order.Services.Consumers
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEfGenericRepository<Infrastructure.Entities.Order> _orderRepository;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection,
            IMapper mapper,
            IMediator mediator,
            IEfGenericRepository<Infrastructure.Entities.Order> orderRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _orderRepository = orderRepository;
            _connection = connection;
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.BasketCheckoutQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.BasketCheckoutQueue, autoAck: true, consumer: consumer, noLocal:false, exclusive: false, arguments: null);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConstants.BasketCheckoutQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var checkoutEventModel = JsonConvert.DeserializeObject<ShoppingCartCheckoutEvent>(message);

                var command = _mapper.Map<CheckoutOrderCommand>(checkoutEventModel);
                await _mediator.Send(command);
            }
        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
