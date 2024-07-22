using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Name")]
        public string Title { get; set; }
    }
}
