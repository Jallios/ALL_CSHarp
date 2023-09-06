using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEREKYP2.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace PEREKYP2.Controllers
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
            return View(await db.Users.ToListAsync());
        }
        public IActionResult FIRSTPAGE()
        {
            return View();
        }
        public async Task<IActionResult> AUTO()
        {
            return View(await db.Autos.ToListAsync());
        }

        public IActionResult Admin()
        {
            AdminModel model = new AdminModel
            {
                autos = db.Autos.ToListAsync().Result,
                users = db.Users.ToListAsync().Result,
                historyAutos = db.HistoryAutos.ToListAsync().Result,
                purchaseStatuses = db.PurchaseStatuses.ToListAsync().Result,
                userRoles = db.UserRoles.ToListAsync().Result
            };
            return View(model);
        }

        public IActionResult SignIn()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LOGINMODEL model)
        {

            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginUser == model.Login && u.PasswordUser == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login); // аутентификация
                    if (user.UserRoleId == 3)
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");


            }

            return RedirectToAction("SignIn", "Home");

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
            return RedirectToAction("SignIn");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User person)
        {

            db.Users.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("SignIn");

            //else
            //{
            // return View(person);
            //}

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

        public IActionResult CreateAuto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuto(Auto Auto)
        {
            db.Autos.Add(Auto);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> EditAuto(int? id)
        {
            if (id != null)
            {
                Auto Auto = await db.Autos.FirstOrDefaultAsync(p => p.IdAuto == id);
                if (Auto != null)
                {
                    return View(Auto);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditAuto(Auto Auto)
        {
            db.Autos.Update(Auto);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [ActionName("DeleteAuto")]

        public async Task<IActionResult> ConfrimDeleteAuto(int? id)
        {
            if (id != null)
            {
                Auto Auto = await db.Autos.FirstOrDefaultAsync(p => p.IdAuto == id);
                if (Auto != null)
                {
                    return View(Auto);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> DeleteAuto(int? id)
        {
            if (id != null)
            {
                Auto Auto = await db.Autos.FirstOrDefaultAsync(p => p.IdAuto == id);
                if (Auto != null)
                {
                    db.Autos.Remove(Auto);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Admin");
                }
            }
            return NotFound();
        }

        public IActionResult CreateUserRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserRole(UserRole userRole)
        {
            db.UserRoles.Add(userRole);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> EditUserRole(int? id)
        {
            if (id != null)
            {
                UserRole userRole = await db.UserRoles.FirstOrDefaultAsync(p => p.IdUserRole == id);
                if (userRole != null)
                {
                    return View(userRole);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRole(UserRole userRole)
        {
            db.UserRoles.Update(userRole);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [ActionName("DeleteUserRole")]

        public async Task<IActionResult> ConfrimDeleteUserRole(int? id)
        {
            if (id != null)
            {
                UserRole userRole = await db.UserRoles.FirstOrDefaultAsync(p => p.IdUserRole == id);
                if (userRole != null)
                {
                    return View(userRole);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> DeleteUserRole(int? id)
        {
            if (id != null)
            {
                UserRole userRole = await db.UserRoles.FirstOrDefaultAsync(p => p.IdUserRole == id);
                if (userRole != null)
                {
                    db.UserRoles.Remove(userRole);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Admin");
                }
            }
            return NotFound();
        }

        public IActionResult CreateHistoryAuto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistoryAuto(HistoryAuto historyAuto)
        {
            db.HistoryAutos.Add(historyAuto);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> EditHistoryAuto(int? id)
        {
            if (id != null)
            {
                HistoryAuto historyAuto = await db.HistoryAutos.FirstOrDefaultAsync(p => p.IdHistoryAuto == id);
                if (historyAuto != null)
                {
                    return View(historyAuto);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditHistoryAuto(HistoryAuto historyAuto)
        {
            db.HistoryAutos.Update(historyAuto);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [ActionName("DeleteHistoryAuto")]

        public async Task<IActionResult> ConfrimDeleteHistoryAuto(int? id)
        {
            if (id != null)
            {
                HistoryAuto historyAuto = await db.HistoryAutos.FirstOrDefaultAsync(p => p.IdHistoryAuto == id);
                if (historyAuto != null)
                {
                    return View(historyAuto);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> DeleteHistoryAuto(int? id)
        {
            if (id != null)
            {
                HistoryAuto historyAuto = await db.HistoryAutos.FirstOrDefaultAsync(p => p.IdHistoryAuto == id);
                if (historyAuto != null)
                {
                    db.HistoryAutos.Remove(historyAuto);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Admin");
                }
            }
            return NotFound();
        }


        public IActionResult CreatePurchaseStatus()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseStatus(PurchaseStatus purchaseStatus)
        {
            db.PurchaseStatuses.Add(purchaseStatus);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> EditPurchaseStatus(int? id)
        {
            if (id != null)
            {
                PurchaseStatus purchaseStatus = await db.PurchaseStatuses.FirstOrDefaultAsync(p => p.IdPurchaseStatus == id);
                if (purchaseStatus != null)
                {
                    return View(purchaseStatus);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditPurchaseStatus(PurchaseStatus purchaseStatus)
        {
            db.PurchaseStatuses.Update(purchaseStatus);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [ActionName("DeletePurchaseStatus")]

        public async Task<IActionResult> ConfrimDeletePurchaseStatus(int? id)
        {
            if (id != null)
            {
                PurchaseStatus purchaseStatus = await db.PurchaseStatuses.FirstOrDefaultAsync(p => p.IdPurchaseStatus == id);
                if (purchaseStatus != null)
                {
                    return View(purchaseStatus);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> DeletePurchaseStatus(int? id)
        {
            if (id != null)
            {
                PurchaseStatus purchaseStatus = await db.PurchaseStatuses.FirstOrDefaultAsync(p => p.IdPurchaseStatus == id);
                if (purchaseStatus != null)
                {
                    db.PurchaseStatuses.Remove(purchaseStatus);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Admin");
                }
            }
            return NotFound();
        }


        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        [ActionName("DeleteUser")]

        public async Task<IActionResult> ConfrimDeleteUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.IdUser == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Admin");
                }
            }
            return NotFound();
        }
        public IActionResult Support()
        {
            return View();
        }

        public IActionResult SendMail(SupportModel send)
        {
                MailAddress from = new MailAddress("jallios@mail.ru", "PEREKYP2");
                MailAddress to = new MailAddress(send.Email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Обращение от пользователя";
                m.Body = "Сообщение отправлено. Спасибо Вам " + send.Name + ", мы скоро свяжемся с Вами.";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("jallios@mail.ru", "Vaq34kJHY59JWDpRdabT");
                smtp.EnableSsl = true;
                smtp.Send(m);

                MailAddress too = new MailAddress("jallios@mail.ru", "PEREKYP2");
                MailMessage mo = new MailMessage(too, too);
                mo.Subject = "Обращение от пользователя " + send.Email;
                mo.Body = send.Message;
                mo.IsBodyHtml = true;

                smtp.Credentials = new NetworkCredential("jallios@mail.ru", "Vaq34kJHY59JWDpRdabT");
                smtp.EnableSsl = true;
                smtp.Send(mo);

            return View("FIRSTPAGE");
        }
    }
}
