using Domin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.ViewModels
{
    public class subCategoryViewModel
    {
        public List<subCategory> subCategories {  get; set; }
       public List<Category> categories { get; set; }
 
        public NewSubCategory NewSubCategory { get; set; }
       
    }
    public class NewSubCategory
    {
        public int? Id { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Title is requires")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is requires")]
        public string Description { get; set; }
     
        public int CategoryId { get; set; }


    }
}
