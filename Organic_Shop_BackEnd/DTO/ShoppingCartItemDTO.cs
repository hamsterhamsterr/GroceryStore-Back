
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.DTO
{
    public class ShoppingCartItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public GetProductDTO Product { get; set; }
    }
}
