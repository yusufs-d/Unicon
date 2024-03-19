using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unicon.Data;
using Unicon.Models;

namespace Unicon.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { 
                    UserName = model.Username, 
                    Email = model.Email, 
                    RealName = model.RealName, 
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true,
                    CreateDate = DateTime.UtcNow };

                var password = model.Password ?? throw new ArgumentNullException(nameof(model.Password));

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError(string.Empty, "Giriş başarısız. Lütfen geçerli bir kullanıcı adı ve parola girin.");
        return View(model);
    }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
