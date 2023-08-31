namespace Organic_Shop_BackEnd.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public long DateCreated { get; set; }
        public IList<OrderItemDTO> OrderItems { get; set; }
    }
}
