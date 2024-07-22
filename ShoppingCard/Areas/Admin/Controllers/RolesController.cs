using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ShoppingCard.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin , Admin")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
       
        private readonly ShoppingCardDbContext _context;
      

        public RolesController(RoleManager<IdentityRole> roleManager, ShoppingCardDbContext context )
                                
        {
            _roleManager = roleManager;
           
            _context = context;
          
        }

        // Role
        [HttpGet]
        public  IActionResult Role()
        {
            var role = new RolesViewModel()
            {
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                newRole = new NewRole()
            };
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Role(RolesViewModel model)
        {
            var role = new IdentityRole()
            {
                Id = model.newRole.RoleId,
                Name = model.newRole.RoleName,
            };

            if (ModelState.IsValid)
            {
                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        SessionMsg(Helper.Success, Helper.Save, Helper.SuccessSave);
                        return RedirectToAction("Role");


                    }
                    else
                    {
                        SessionMsg(Helper.Error, Helper.Error, Helper.NotSave);
                        return RedirectToAction("Role");


                    }

                }
                else
                {
                    var roleUpdated = await _roleManager.FindByIdAsync(role.Id);
                    roleUpdated.Name = role.Name;
                    roleUpdated.Id = role.Id;
                    var result = await _roleManager.UpdateAsync(roleUpdated);

                    if (result.Succeeded)
                    {
                        SessionMsg(Helper.Success, Helper.Update, Helper.SuccessUpdate);
                        return RedirectToAction("Role");

                    }
                    else
                    {
                        SessionMsg(Helper.Error, Helper.Error, Helper.NotUpdate);
                        return RedirectToAction("Role");
                    }
                }
            }

            return RedirectToAction("Role");

        }
       
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = _roleManager.Roles.SingleOrDefault(x => x.Id == Id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                SessionMsg(Helper.Success, Helper.Delete, Helper.SuccessDelete);

            }
            return RedirectToAction("Role","Roles");
        }

        // Role

       

       

       

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }
    }
}
