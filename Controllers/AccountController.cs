using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookLibraryApp.Models;

namespace BookLibraryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager; // Fixed the field declaration
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Registration page (GET)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Registration page (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Books");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        // Login page (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("ManageBooks", "Admin");
                    }
                    return RedirectToAction("Index", "Books");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }


        // Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Books");
        }
    }
}
