using Domin.Models;
using Infrastructure_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> signInManager , UserManager<ApplicationUser> userManager)
        {
           _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // login use email or userName 
            var username = new EmailAddressAttribute().IsValid(model.Email) ? _userManager.FindByEmailAsync(model.Email).Result.UserName : model.Email;
            if (ModelState.IsValid)
            {
                var user = await _signInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, false);

                if (user.Succeeded)
                { //SessionMsg(Helper.Success, "Login", "Login Successfully");
                    return RedirectToAction("Register", "Register");
                }
                else
                {
                    ViewBag.ErrorLog = false;
                }

            }
            return View(model);
        }

      
    }
}
