namespace Kanbersky.CleanArch.Basket.Services.DTO.Response
{
    public class CheckoutResponseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        //Billing Address
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
