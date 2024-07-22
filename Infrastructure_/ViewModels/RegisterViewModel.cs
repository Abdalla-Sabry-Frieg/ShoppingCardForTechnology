using Domin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.ViewModels
{
    public class RegisterViewModel
    {
        public List<UserView> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public NewRegister  NewRegister { get; set; }
        public  ChangePasswordViewModel ChangePassword { get; set; }    
    }

    public class NewRegister
    {
        public string Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "RegisterName")]
        public string Name { get; set; }

       [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "RoleName")]
        public string RoleName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "EmailName")]
        [EmailAddress(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "EmailNameError")]
        public string Email { get; set; }
        public string ImageUser { get; set; }
        public bool ActiveUser { get; set; }

        [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "Password")]

        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "ComparPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(Domin.ModelsResource), ErrorMessageResourceName = "ComparPasswordError")]
        public string ComparePassword { get; set; }
    }
}
