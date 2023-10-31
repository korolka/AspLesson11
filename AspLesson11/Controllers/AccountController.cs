using AspLesson11.Database;
using AspLesson11.Models;
using AspLesson11.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspLesson11.Controllers
{
    public class AccountController : Controller
    {
        IPasswordHasher hasher;
        public AccountController(IPasswordHasher hasher)
        {
            this.hasher = hasher;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInBindingModel model)
        {
            if (ModelState.IsValid)
            {
                using (NoteContext context = new NoteContext())
                {
                    var user = context.Users.
                        FirstOrDefault(us => us.Email == model.Email);
                    if (user is AspLesson11.Database.User)
                    {
                        if (user.Password == hasher.GeneratePassword(model.Password))
                        {
                            SignInAsync(user);
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Password or login not exist ");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password or login not exist");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationBindingModel model)
        {
            if (ModelState.IsValid)
            {
                using (NoteContext context = new NoteContext())
                {
                    bool ExistEmail = context.Users.Any(us => us.Email == model.Email);
                    if (ExistEmail)
                    {
                        ModelState.AddModelError(string.Empty, "This email is exist");
                        return View(model);
                    }
                    else
                    {
                        AspLesson11.Database.User user = new User()
                        {
                            Email = model.Email,
                            Password = hasher.GeneratePassword(model.Password)
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("SignIn", "Account");
                    }
                }
            }
            return View(model);
        }

        private async Task SignInAsync(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };
            var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name,ClaimTypes.Role);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(claimPrincipal);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
