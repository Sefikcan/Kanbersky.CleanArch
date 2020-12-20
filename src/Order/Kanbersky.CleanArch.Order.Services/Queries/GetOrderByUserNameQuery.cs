using Kanbersky.CleanArch.Order.Services.DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanbersky.CleanArch.Order.Services.Queries
{
    public class GetOrderByUserNameQuery : IRequest<IEnumerable<OrderResponseModel>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
