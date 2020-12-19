using System.Collections.Generic;

namespace Kanbersky.CleanArch.Basket.Services.DTO.Request
{
    public class AddOrUpdateShoppingCartRequestModel
    {
        public string UserName { get; set; }

        public List<ShoppingCartItemRequestModel> Items { get; set; } = new List<ShoppingCartItemRequestModel>();
    }

    public class ShoppingCartItemRequestModel
    {
        public int Quantity { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
