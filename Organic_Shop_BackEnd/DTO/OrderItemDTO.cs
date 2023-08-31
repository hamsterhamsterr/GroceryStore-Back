namespace Organic_Shop_BackEnd.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public GetProductDTO Product { get; set; }
    }
}
