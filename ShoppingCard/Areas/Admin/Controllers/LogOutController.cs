using Domin.Models;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogOutController : Controller
    {
       private readonly SignInManager<ApplicationUser> _signInManager;
        public LogOutController(SignInManager<ApplicationUser>signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut(LoginViewModel model)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login" , "Login");
        }
    }
}
