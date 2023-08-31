﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Organic_Shop_BackEnd.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
