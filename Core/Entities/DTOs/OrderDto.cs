namespace Core.Entities.DTOs
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AppUserDto ShipToAddress { get; set; }
    }
}