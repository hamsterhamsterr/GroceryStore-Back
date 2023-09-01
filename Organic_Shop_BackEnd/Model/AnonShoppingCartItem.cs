using System.ComponentModel.DataAnnotations.Schema;

namespace Organic_Shop_BackEnd.Model
{
    public class AnonShoppingCartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(AnonShoppingCart))]
        public int AnonShoppingCartId { get; set; }
        public AnonShoppingCart AnonShoppingCart { get; set; }
    }
}
