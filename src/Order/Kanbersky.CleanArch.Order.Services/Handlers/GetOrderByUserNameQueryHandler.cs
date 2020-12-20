using AutoMapper;
using Kanbersky.CleanArch.Core.Repositories.Abstract.EntityFramework;
using Kanbersky.CleanArch.Order.Services.DTO.Response;
using Kanbersky.CleanArch.Order.Services.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Order.Services.Handlers
{
    public class GetOrderByUserNameQueryHandler : IRequestHandler<GetOrderByUserNameQuery, IEnumerable<OrderResponseModel>>
    {
        private readonly IEfGenericRepository<Infrastructure.Entities.Order> _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByUserNameQueryHandler(IEfGenericRepository<Infrastructure.Entities.Order> orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponseModel>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAsync(x => x.UserName == request.UserName);
            return _mapper.Map<IEnumerable<OrderResponseModel>>(orders);
        }
    }
}
