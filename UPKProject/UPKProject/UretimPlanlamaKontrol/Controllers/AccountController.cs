using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UretimPlanlamaKontrol.Models;

namespace UretimPlanlamaKontrol.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user=await _userManager.FindByNameAsync(model.Name);
                if(user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password.");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            string errorMessage = "bir hata oluştu";
            
            var result=await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                var roleResut = await _userManager
                    .AddToRoleAsync(user, "User");

                if (roleResut.Succeeded)
                    return RedirectToAction("Login", new {ReturnUrl="/"});
            }
            else
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("",err.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")] string returnUrl)     //parametresini tanımladığımız logici işletmedik
        {
            return View();
        }


    }
}
