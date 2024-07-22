using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Models
{
    public class UserView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public bool ActiveUser { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
