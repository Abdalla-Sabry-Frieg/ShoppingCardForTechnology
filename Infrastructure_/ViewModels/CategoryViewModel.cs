using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.ViewModels
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }
        public List<Item> Items { get; set; }
        public List<Category> Categories { get; set; }
        
        public NewCategory newCategory { get; set; }

        public class NewCategory
        {
            public int? Id { get; set; }
            public string Image { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

            public int? parantId  { get; set; }
        }

    }
}
