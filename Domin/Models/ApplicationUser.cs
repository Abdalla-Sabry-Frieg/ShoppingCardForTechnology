using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class ApplicationUser : IdentityUser
    {
       // public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public bool ActiveUser { get; set; }
     
    }
}
