using Domin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure_.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Password")]
      //  [DataType(DataType.Password)]
        public string OldPassword { get; set; }

       // [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "ComparPassword")]
       // [DataType(DataType.Password)]
        //[Compare("NewPassword")]
        public string ComparPassword { get; set; }
    }
}
