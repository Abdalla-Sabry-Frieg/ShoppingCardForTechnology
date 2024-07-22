using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class Category
    {
        public int? Id { get; set; } 
        public string Image { get; set; }
        [Required(ErrorMessage ="Title is requires")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Title is requires")]
        public string Description { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public List<Item>? Items { get; set; }
       
    }
}
