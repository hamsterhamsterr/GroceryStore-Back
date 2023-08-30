using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public long DateCreated { get; set; }
        public IList<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
    }
}
