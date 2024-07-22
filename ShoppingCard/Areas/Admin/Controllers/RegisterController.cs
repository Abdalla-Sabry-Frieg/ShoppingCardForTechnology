using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCard.Areas.Admin.Controllers
{
   [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ShoppingCardDbContext _context;
       

        public RegisterController(RoleManager<IdentityRole> roleManager,
                                  UserManager<ApplicationUser> userManager,
                                  ShoppingCardDbContext context )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            var user = new RegisterViewModel()
            {
                NewRegister = new NewRegister(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                Users = _context.UsersView.OrderBy(x => x.Name).ToList()
            };


            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {


            Image(model);

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Id = model.NewRegister.Id,
                    Name = model.NewRegister.Name,
                    UserName = model.NewRegister.Email,
                    Email = model.NewRegister.Email,
                    ActiveUser = model.NewRegister.ActiveUser,
                    ImageUser = model.NewRegister.ImageUser,


                };
                //Create new user
                if (user.Id == null)
                {
                    user.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, model.NewRegister.Password);
                    var NewRole = await _userManager.AddToRoleAsync(user, model.NewRegister.RoleName);
                    if (result.Succeeded)
                    {


                        SessionMsg(Helper.Success, Helper.Save, Helper.SaveUser);


                        return RedirectToAction("Register","Register");

                    }
                    else
                    {
                        SessionMsg(Helper.Error, Helper.NotSave, Helper.NotSave);


                        return RedirectToAction("Register", "Register");
                    }
                }
                // update 
                else
                {
                    Image(model);

                    var userUpdate = await _userManager.FindByIdAsync(user.Id);

                    userUpdate.Id = model.NewRegister.Id;
                    userUpdate.Name = model.NewRegister.Name;
                    userUpdate.Email = model.NewRegister.Email;
                    userUpdate.ActiveUser = model.NewRegister.ActiveUser;
                    userUpdate.ImageUser = model.NewRegister.ImageUser;
                    var resut = await _userManager.UpdateAsync(userUpdate);

                    if (resut.Succeeded)
                    {
                        var oldRole = await _userManager.GetRolesAsync(userUpdate);
                        await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
                        var newRole = await _userManager.AddToRoleAsync(userUpdate, model.NewRegister.RoleName);

                        SessionMsg(Helper.Success, Helper.Update, Helper.SuccessUpdate);


                        return RedirectToAction("Register", "Register");
                    }
                    else
                    {
                        SessionMsg(Helper.Error, Helper.NotUpdate, Helper.NotUpdate);


                        return RedirectToAction("Register", "Register");
                    }

                }


            }
            return RedirectToAction("Register");
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user.ImageUser != null && user.ImageUser != Guid.Empty.ToString())
            {
                var imagePath = Path.Combine(@"wwwroot/", Helper.imagesSaveUsers, user.ImageUser);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                SessionMsg(Helper.Success, Helper.Delete, Helper.SuccessDelete);


                return RedirectToAction("Register", "Register");
            }
            else
            {
                SessionMsg(Helper.Error, Helper.Delete, Helper.DeleteFaild);

                return RedirectToAction("Register", "Register");
            }
        }

        private void Image(RegisterViewModel model)
        {
            var file = HttpContext.Request.Form.Files;
            //Create
            if (file.Count() > 0)
            {
                var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.imagesSaveUsers, ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.NewRegister.ImageUser = ImageName;
            }
            else if (model.NewRegister.ImageUser == null && model.NewRegister.Id == null)
            {
                model.NewRegister.ImageUser = "Defult.png";
            }
            else // Update
            {
                model.NewRegister.ImageUser = model.NewRegister.ImageUser;
            }
        }


        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }
    }
}
