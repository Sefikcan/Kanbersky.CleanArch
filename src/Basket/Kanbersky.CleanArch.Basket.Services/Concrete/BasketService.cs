using AutoMapper;
using Kanbersky.CleanArch.Basket.Services.Abstract;
using Kanbersky.CleanArch.Basket.Services.DTO.Request;
using Kanbersky.CleanArch.Basket.Services.DTO.Response;
using Kanbersky.CleanArch.Core.Caching.Abstract;
using Kanbersky.CleanArch.Core.Constants;
using Kanbersky.CleanArch.Core.Messaging.Events;
using Kanbersky.CleanArch.Core.Messaging.Producer;
using Kanbersky.CleanArch.Core.Results.Exceptions.Concrete;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Basket.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBus;

        public BasketService(ICacheService cacheService,
            IMapper mapper,
            EventBusRabbitMQProducer eventBus)
        {
            _cacheService = cacheService;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<ShoppingCartResponseModel> AddOrUpdateShoppingCart(AddOrUpdateShoppingCartRequestModel addOrUpdateShoppingCartRequest)
        {
            var response = await _cacheService.AddAsync(addOrUpdateShoppingCartRequest.UserName, addOrUpdateShoppingCartRequest, CacheConstants.CacheAbsoluteExpiration);
            return _mapper.Map<ShoppingCartResponseModel>(response);
        }

        public async Task DeleteShoppingCart(string userName)
        {
            await _cacheService.RemoveAsync(userName);
        }

        public async Task<ShoppingCartResponseModel> GetShoppingCart(string userName)
        {
            return await _cacheService.GetAsync<ShoppingCartResponseModel>(userName);
        }

        public async Task<CheckoutResponseModel> BasketCheckout(CheckoutRequestModel checkoutRequest)
        {
            var basket = await _cacheService.GetAsync<ShoppingCartResponseModel>(checkoutRequest.UserName);
            if (basket == null)
            {
                throw BaseException.NotFoundException("Shopping Cart Is Empty!");
            }

            await _cacheService.RemoveAsync(checkoutRequest.UserName);

            var eventModel = _mapper.Map<ShoppingCartCheckoutEvent>(checkoutRequest);
            eventModel.RequestId = eventModel.RequestId;
            eventModel.TotalPrice = basket.TotalPrice;

            _eventBus.PublishBasketCheckout(EventBusConstants.BasketCheckoutQueue, eventModel);

            return _mapper.Map<CheckoutResponseModel>(eventModel);
        }
    }
}
