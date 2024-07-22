using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class subCategory
    {
        [Key]
        public int? Id { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Title is requires")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Title is Description")]
        public string Description { get; set; }
       
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public  Category Category { get; set; }
       // public List<Item> Items { get; set; }
    }
}
