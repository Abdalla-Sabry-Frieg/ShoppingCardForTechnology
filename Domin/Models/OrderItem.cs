using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class OrderItem
    {
        public OrderItem(int itemId, decimal price, int quantity, decimal total)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
            Total = total;
        }

        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
