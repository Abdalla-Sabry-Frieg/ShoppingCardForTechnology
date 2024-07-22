using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.Repository.IRepository;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCard.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCardDbContext _context;

        public ItemsController(IUnitOfWork unitOfWork, ShoppingCardDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public IActionResult Index(int? id=null)
        {
            ViewBag.CategoeyTitle = _unitOfWork.Categories.FindAll().Where(x => x.Id == id).ToList();
            var items = new ItemsViewModel()
            {
                 items = _unitOfWork.Items.FindAll().Where(x => x.CategoryId == id),
              
                
            };
            return View(items);
        }
        public IActionResult AddOrpUdate(ItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
               if(model.NewItem.ItemId == null)
                {
                    Image(model);
                    var item = new Item()
                    {
                        Id = model.NewItem.ItemId,
                        Title = model.NewItem.Title,
                        Description = model.NewItem.Description,
                        Image = model.NewItem.Image,
                        CategoryId = model.NewItem.CategoryId, 
                        Price = model.NewItem.Price,
                    };
                    _unitOfWork.Items.AddOne(item);
                    SessionMsg(Helper.Success, Helper.Save, Helper.SuccessSave);
                   
                    return RedirectToAction("Index"); 
                }

               else
                {
                    Image(model);
                    var itemUpdate = _unitOfWork.Items.FindById((int)model.NewItem.ItemId);
                    itemUpdate.Id = model.NewItem.ItemId;
                    itemUpdate.Title = model.NewItem.Title;
                    itemUpdate.Description = model.NewItem.Description;
                    itemUpdate.Image = model.NewItem.Image;
                    itemUpdate.CategoryId = model.NewItem.CategoryId;
                    itemUpdate.Price = model.NewItem.Price;

                    _unitOfWork.Items.UpdateOne(itemUpdate);
                    SessionMsg(Helper.Success, Helper.Update, Helper.SuccessUpdate);
                    return RedirectToAction("Index", "Items");
                }
            }
            return RedirectToAction("Index", "Items");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var itemDel = _unitOfWork.Items.First(x => x.Id == id);
                if (itemDel == null)
                {
                    return NotFound();
                }

                if (itemDel.Image != null && itemDel.Image != Guid.Empty.ToString())
                {
                    var pathimage = Path.Combine(@"wwwroot/", Helper.imagesSaveCategory, itemDel.Image);
                    if (System.IO.File.Exists(pathimage))
                    {
                        System.IO.File.Delete(pathimage);
                    }
                }
                _unitOfWork.Items.DeleteOne(itemDel);
                SessionMsg(Helper.Success, Helper.Delete, Helper.SuccessDelete);
                return RedirectToAction("Index", "Items");
            }

            return RedirectToAction("Index", "Items");
        }



        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }

        private void Image(ItemsViewModel model)
        {
            var file = HttpContext.Request.Form.Files;
            //Create
            if (file.Count() > 0)
            {
                var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.imagesSaveItems, ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.NewItem.Image = ImageName;
            }
            else if (model.NewItem.Image == null && model.NewItem.ItemId == null)
            {
                model.NewItem.Image = "Defult.png";
            }
            else // Update
            {
                model.NewItem.Image = model.NewItem.Image;
            }
        }
    }
}
