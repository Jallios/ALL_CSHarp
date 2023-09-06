using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private GalleryContext db;
        public HomeController(GalleryContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Photos.ToListAsync());
        }

        public IActionResult CreatePhoto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhoto(Photo photo)
        {
            db.Photos.Add(photo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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