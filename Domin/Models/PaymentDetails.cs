using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class PaymentDetails
    {
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public decimal Tax { get; set; }
        public string Currency { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public int UserId { get; set; }
        public decimal FinalTotal { get; set; }


    }
}
