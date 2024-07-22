using Domin.Models;
using Infrastructure_.DataBase;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCard.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ChangePasswordController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ShoppingCardDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ChangePasswordController( UserManager<ApplicationUser> userManager, ShoppingCardDbContext context,
                                  SignInManager<ApplicationUser> signInManager)
        {
           
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.ChangePassword.Id);
                if (user == null)
                {
                    // User not found
                    SessionMsg(Helper.Error, Helper.Password, Helper.notFound);
                    return RedirectToAction("Register" , "Register");
                }
                else
                {
                    await _userManager.RemovePasswordAsync(user);
                    var changePasswordResult = await _userManager.AddPasswordAsync(user, model.ChangePassword.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {
                        // Password changed successfully
                        // await _signInManager.RefreshSignInAsync(user);

                        SessionMsg(Helper.Success, Helper.Password, Helper.changed);
                        return RedirectToAction("Register", "Register");

                    }
                    else
                    {
                        foreach (var error in changePasswordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        SessionMsg(Helper.Error, Helper.Password, Helper.NotSave);

                        return RedirectToAction("Register", "Register");
                    }
                }
            }
            return RedirectToAction("Register", "Register");
        }

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }
    }
}
