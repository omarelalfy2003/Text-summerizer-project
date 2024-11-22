using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SummarizationApp.Models;

namespace SummarizationApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flagvalid = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (flagvalid)
                    {
                        var password = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        //if (password.Succeeded && await _userManager.IsInRoleAsync(user, "Admin"))
                        //    return RedirectToAction("Index", "Home");
                        //else if (password.Succeeded && await _userManager.IsInRoleAsync(user, "User"))
                        //    return RedirectToAction("Index", "DisplayNews");
                        //else
                        //{
                        //    await _userManager.AddToRoleAsync(user, "User");
                        //    return RedirectToAction("Index", "DisplayNews");
                        //}
                        if (password.Succeeded)
                            return RedirectToAction("Index","Home");
                    }
                    else
                        ModelState.AddModelError(" ", "The Email or Password Incorrect");
                }
                else
                    ModelState.AddModelError("", "The User Not Exist");
            }
            return View(model);

        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    ModelState.AddModelError(" ", "The User Is already Exist");
                }
                else
                {
                    var users = new ApplicationUser()
                    {
                        Email = model.Email,
                        DisplayName = model.Name,
                        IsAgree = model.IsAgree,
                        UserName = model.Email.Split("@")[0],

                    };
                    var result = await _userManager.CreateAsync(users, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(model);

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Summrization()
        {
            return View();  
        }
    }
}
