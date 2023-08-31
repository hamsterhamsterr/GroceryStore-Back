namespace Organic_Shop_BackEnd.DTO
{
    public class GetOrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public GetProductDTO Product { get; set; }
    }

    public class CreateOrderItemDTO
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
