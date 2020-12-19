using System.Collections.Generic;

namespace Kanbersky.CleanArch.Basket.Services.DTO.Response
{
    public class ShoppingCartResponseModel
    {
        public string UserName { get; set; }

        public List<ShoppingCartItemResponseModel> Items { get; set; } = new List<ShoppingCartItemResponseModel>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }
    }

    public class ShoppingCartItemResponseModel
    {
        public int Quantity { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
