namespace Organic_Shop_BackEnd.DTO
{

    public class GetOrderDTO
    {
        public int Id { get; set; }
        public long DatePlaced { get; set; }
        public string UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CustomerName { get; set; }
        public IList<GetOrderItemDTO> OrderItems { get; set; }
    }

    public class CreateOrderDTO
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CustomerName { get; set; }
        public IList<CreateOrderItemDTO> OrderItems { get; set; }
    }
}
