using System.ComponentModel.DataAnnotations.Schema;

namespace Organic_Shop_BackEnd.Model
{
    public class Order
    {
        public int Id { get; set; }
        public long datePlaced { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApiUser User { get; set; }

        //Shipping
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CustomerName { get; set; }

        //Items
        public IList<OrderItem> OrderItems { get; set; }
    }
}
