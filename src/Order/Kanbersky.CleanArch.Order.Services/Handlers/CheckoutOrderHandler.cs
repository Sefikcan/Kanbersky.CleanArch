using AutoMapper;
using Kanbersky.CleanArch.Core.Repositories.Abstract.EntityFramework;
using Kanbersky.CleanArch.Core.Results.Exceptions.Concrete;
using Kanbersky.CleanArch.Order.Services.Commands;
using Kanbersky.CleanArch.Order.Services.DTO.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Order.Services.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponseModel>
    {
        private readonly IEfGenericRepository<Infrastructure.Entities.Order> _orderRepository;
        private readonly IMapper _mapper;

        public CheckoutOrderHandler(IEfGenericRepository<Infrastructure.Entities.Order> orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        
        public async Task<OrderResponseModel> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Infrastructure.Entities.Order>(request);
            if (orderEntity == null)
            {
                throw BaseException.BadRequestException("Order not mapped");
            }

            var newOrder = await _orderRepository.AddAsync(orderEntity);
            return _mapper.Map<OrderResponseModel>(newOrder);
        }
    }
}
