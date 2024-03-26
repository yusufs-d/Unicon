using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;
using Unicon.Data;
using Unicon.Filters;
using Unicon.Models;

namespace Unicon.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [RedirectToHomeIfLoggedIn]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [RedirectToHomeIfLoggedIn]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Username != null)
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                {
                    ModelState.AddModelError("alreadyexists", "Bu kullanıcı adı zaten kullanımda.");
                    return View(model);
                }
            }



            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    RealName = model.RealName,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true,
                    CreateDate = DateTime.UtcNow
                };

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

        [RedirectToHomeIfLoggedIn]
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [RedirectToHomeIfLoggedIn]
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

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("LoginError", "Lütfen kullanıcı adı ya da şifrenizi kontrol ediniz!");
                    return View(model);
                }
            }
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User");
        }

        [RedirectIfNotAdmin]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }

        [RedirectIfNotAdmin]
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
        
            }

            try{
 var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı silme işlemi başarısız oldu.");
                return View("UserList");

            }
            
            }catch{
                TempData["DeleteError"] = "Kullanıcı silme başarısız. Kullanıcının yorum yapması buna engel oluyor olabilir. Lütfen kontrol ediniz.";
                return RedirectToAction("UserList");
            }

           
        }

        [RedirectIfNotAdmin]
        public async Task<IActionResult> AddAdminRoleToUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                var adminRole = new IdentityRole("Admin");
                var createRoleResult = await _roleManager.CreateAsync(adminRole);
                if (!createRoleResult.Succeeded)
                {
                    return StatusCode(500, "Admin rolü oluşturma hatası!");
                }
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
            if (!addToRoleResult.Succeeded)
            {
                return StatusCode(500, "Admin rolü oluşturma hatası!");
            }

            return RedirectToAction("UserList");
        }

        [RedirectIfNotAdmin]
        public async Task<IActionResult> RemoveAdminRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
            if (!result.Succeeded)
            {
                return StatusCode(500,"Admin silme işlemi başarısız oldu!");
            }

            return RedirectToAction("UserList");
        }





    }


}
