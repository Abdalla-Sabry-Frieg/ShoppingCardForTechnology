using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.Repository.IRepository;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCard.Controllers
{
  
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCardDbContext _context;

        public CategoryController(IUnitOfWork unitOfWork , ShoppingCardDbContext context)
        {
            _unitOfWork = unitOfWork; 
           _context = context;
        }
        //
        public IActionResult Categories(int? id=null)
        {
            ViewBag.CategoeyTitle = _context.Categories.Where(x=>x.Id == id).ToList();
            var result = new CategoryViewModel
            {
                Categories = _unitOfWork.Categories.FindAll().Where(c=>c.ParentId==id).ToList(),
               
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.newCategory.Id == null)
                {
                    Image(model);
                    var category = new Category()
                    {
                        Id = model.newCategory.Id,
                        Description = model.newCategory.Description,
                        Title = model.newCategory.Title,
                        Image = model.newCategory.Image,
                        ParentId=model.newCategory.parantId
                    };
                    _unitOfWork.Categories.AddOne(category);
                    SessionMsg(Helper.Success, Helper.Save, Helper.SuccessSave);
                    return RedirectToAction("Categories");

                }
                else
                {
                    Image(model);
                    var categoryUpdated = _unitOfWork.Categories.FindById((int)model.newCategory.Id);
                    categoryUpdated.Id = model.newCategory.Id.Value;
                    categoryUpdated.Description = model.newCategory.Description;
                    categoryUpdated.Title = model.newCategory.Title;
                    categoryUpdated.Image = model.newCategory.Image;
                    categoryUpdated.ParentId = model.newCategory.parantId;

                    _unitOfWork.Categories.UpdateOne(categoryUpdated);
                    SessionMsg(Helper.Success, Helper.Update, Helper.SuccessUpdate);
                    return RedirectToAction("Categories");
                }
            }
            return RedirectToAction("Categories");
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public IActionResult Delete(int  id)
        {
            if (ModelState.IsValid)
            {
                var cat = _unitOfWork.Categories.First(x => x.Id == id);
                if (cat == null)
                {
                    return NotFound();
                }

                if (cat.Image != null && cat.Image != Guid.Empty.ToString())
                {
                    var pathimage = Path.Combine(@"wwwroot/", Helper.imagesSaveCategory, cat.Image);
                    if (System.IO.File.Exists(pathimage))
                    {
                        System.IO.File.Delete(pathimage);
                    }
                }
                _unitOfWork.Categories.DeleteOne(cat);
              //  _context.SaveChanges();
                SessionMsg(Helper.Success, Helper.Delete, Helper.SuccessDelete);
                return RedirectToAction("Categories");
            }

            return RedirectToAction("Categories");


        }

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }

        private void Image(CategoryViewModel model)
        {
            var file = HttpContext.Request.Form.Files;
            //Create
            if (file.Count() > 0)
            {
                var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.imagesSaveCategory, ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.newCategory.Image = ImageName;
            }
            else if (model.newCategory.Image == null && model.newCategory.Id == null)
            {
                model.newCategory.Image = "Defult.png";
            }
            else // Update
            {
                model.newCategory.Image = model.newCategory.Image;
            }
        }
    }
}
