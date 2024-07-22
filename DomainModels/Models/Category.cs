using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Name")]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

    }
}
