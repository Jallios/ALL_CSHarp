using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TEST.Models;

namespace TEST.Controllers
{
    public class HomeController : Controller
    {

        private TestContext db;

        public HomeController(TestContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View( await db.TestAutos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TestAuto testAuto)
        {
            db.TestAutos.Add(testAuto);
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
        public async Task<IActionResult> Details(int? id)
        {
           if (id != null)
            {
                TestAuto testAuto = await db.TestAutos.FirstOrDefaultAsync(p=>p.IdTestAuto == id);
                if (testAuto != null)
                {
                    return View(testAuto);
                }
            }
            return NotFound();
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if(id != null)
            {
                TestAuto testAuto = await db.TestAutos.FirstOrDefaultAsync(p => p.IdTestAuto == id);
                if (testAuto != null)
                {
                    return View(testAuto);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TestAuto testAuto)
        {
            db.TestAutos.Update(testAuto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]

        public async Task<IActionResult> ConfrimDelete(int? id)
		{
            if (id != null)
            {
                TestAuto testAuto = await db.TestAutos.FirstOrDefaultAsync(p => p.IdTestAuto == id);
                if (testAuto != null)
                {
                    return View(testAuto);
                }
            }
            return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
		{
            if(id != null)
			{
                TestAuto testAuto = await db.TestAutos.FirstOrDefaultAsync(p => p.IdTestAuto == id);
                if (testAuto != null)
                {
                    db.TestAutos.Remove(testAuto);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}