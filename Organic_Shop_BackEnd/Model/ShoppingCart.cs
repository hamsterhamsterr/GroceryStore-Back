using System.ComponentModel.DataAnnotations.Schema;

namespace Organic_Shop_BackEnd.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public long DateCreated { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApiUser User { get; set; }
    }
}
