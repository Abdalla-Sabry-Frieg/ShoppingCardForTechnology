using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.Repository.IRepository;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCard.Controllers
{
    public class subCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCardDbContext _context;

        public subCategoryController(IUnitOfWork unitOfWork , ShoppingCardDbContext context)
        {
            _unitOfWork = unitOfWork;
           _context = context;
        }  
        public IActionResult subCategories()
        {

			var model = new subCategoryViewModel()
            {
                subCategories = _context.subCategories.Include(x=>x.Category).ToList(),
                categories = _unitOfWork.Categories.FindAll().ToList(),
                
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int categoryId)
        {

            var model = _context.subCategories.Where(x => x.CategoryId == categoryId).ToList();
              

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.CategoeyTitle = _context.Categories.ToList();
            var sub = _context.subCategories.Include(c=>c.Category).SingleOrDefault(x => x.Id == id);
            
            return View(sub);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(subCategory model)
        {
            var sub = _context.subCategories.FirstOrDefault(x=>x.Id == model.Id);
            if (sub != null)
            {
                Image(model);
                sub.Id = (int)model.Id;
                sub.Image = model.Image;
                sub.Title = model.Title;
                sub.Description = model.Description;
                sub.CategoryId = model.CategoryId;
                
               
            }

            _unitOfWork.subCategories.UpdateOne(sub);

            return RedirectToAction("categories", "category");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(subCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewSubCategory.Id == null)
                {
                    Image(model);
                    var sub = new subCategory()
                    {
                        Id = (int)model.NewSubCategory.Id.Value,
                        Description = model.NewSubCategory.Description,
                        Title = model.NewSubCategory.Title,
                        Image = model.NewSubCategory.Image,
                        CategoryId = model.NewSubCategory.CategoryId

					};
                    _unitOfWork.subCategories.AddOne(sub);
                    SessionMsg(Helper.Success, Helper.Save, Helper.SuccessSave);
                    return RedirectToAction("categories", "category"); 

                }
                else
                {
		        	Image(model);
                    var categoryUpdated = _unitOfWork.subCategories.FindById((int)model.NewSubCategory.Id);
					categoryUpdated.Id = (int)model.NewSubCategory.Id;
					categoryUpdated.Description = model.NewSubCategory.Description;
					categoryUpdated.Title = model.NewSubCategory.Title;
					categoryUpdated.Image = model.NewSubCategory.Image;
					categoryUpdated.CategoryId = model.NewSubCategory.CategoryId;


					_unitOfWork.subCategories.UpdateOne(categoryUpdated);
					SessionMsg(Helper.Success, Helper.Update, Helper.SuccessUpdate);
                    return RedirectToAction("categories", "category");

                }
               
            }
           // ViewBag.CategoryName = _context.Categories.OrderBy(x => x.Title).ToList();
            return RedirectToAction("categories", "category");
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public IActionResult Delete([FromQuery]int Id)
        {
            if (ModelState.IsValid)
            {
                var cat = _unitOfWork.subCategories.First(x => x.Id == Id);
                if (cat == null)
                {
                    return Json(new { success = false, message = "Item not found." });
                }

                if (cat.Image != null && cat.Image != Guid.Empty.ToString())
                {
                    var pathimage = Path.Combine(@"wwwroot/", Helper.imagesSaveSubCategory, cat.Image);
                    if (System.IO.File.Exists(pathimage))
                    {
                        System.IO.File.Delete(pathimage);
                    }
                }
                _unitOfWork.subCategories.DeleteOne(cat);

                return Json(new { success = true });
            }

            return RedirectToAction("categories", "category");


        }

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }

        private void Image(subCategoryViewModel model)
        {
            var file = HttpContext.Request.Form.Files;
            //Create
            if (file.Count() > 0)
            {
                var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.imagesSaveSubCategory, ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.NewSubCategory.Image = ImageName;
            }
            else if (model.NewSubCategory.Image == null && model.NewSubCategory.Id == null)
            {
                model.NewSubCategory.Image = "Defult.png";
            }
            else // Update
            {
                model.NewSubCategory.Image = model.NewSubCategory.Image;
            }
        }
        private void Image(subCategory model)
        {
            var file = HttpContext.Request.Form.Files;
            //Create
            if (file.Count() > 0)
            {
                var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.imagesSaveSubCategory, ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.Image = ImageName;
            }
            else if (model.Image == null && model.Id == null)
            {
                model.Image = "Defult.png";
            }
            else // Update
            {
                model.Image = model.Image;
            }
        }
    }
}
