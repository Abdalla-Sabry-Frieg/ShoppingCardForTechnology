using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.ViewModels
{
    public class RolesViewModel
    {
        public List<IdentityRole> Roles{ get; set; }
        public  NewRole  newRole {get;set;}
    }
    public class NewRole
    {
        public string RoleId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource),ErrorMessageResourceName = "RoleName")]
        public string RoleName { get; set; }



    }
}
