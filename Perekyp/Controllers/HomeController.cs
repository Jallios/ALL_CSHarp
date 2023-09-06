using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perekyp.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Perekyp.Controllers
{
    public class HomeController : Controller
    {
        private PEREKYPContext db;

        public HomeController(PEREKYPContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Buyers.ToListAsync());
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult REGISTRATION()
        {
            return View();
        }
        public IActionResult FIRSTPAGE()
        {
            return View();
        }
        public IActionResult AUTO()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                Buyer buyer = await db.Buyers.FirstOrDefaultAsync(u => u.LoginBuyer == model.Login && u.PasswordBuyer == model.Password);
                if (buyer != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("AUTO", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");


            }

            return RedirectToAction("Index", "Home");

        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("Index");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(Buyer personb)
        {
            if (ModelState.IsValid)
            {
                db.Buyers.Add(personb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            else
            {
                return View(personb);
            }

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}