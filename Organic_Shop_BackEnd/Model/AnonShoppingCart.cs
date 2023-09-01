using System.ComponentModel.DataAnnotations.Schema;

namespace Organic_Shop_BackEnd.Model
{
    public class AnonShoppingCart
    {
        public int Id { get; set; }
        public long DateCreated { get; set; }

        public string LocalCartId { get; set; }

        public IList<AnonShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
