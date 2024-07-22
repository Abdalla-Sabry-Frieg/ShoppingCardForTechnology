using Domin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class Item
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Name")]
        public string Title { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Price")]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
        [ForeignKey("ItemType")]
      
        public ICollection<OrderItem> OrderItems { get; set; }



    }
}
