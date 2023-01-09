using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager AboutManager = new AboutManager(new EfAboutDalc());

        [HttpGet]
        public IActionResult Index()
        {
            var values = AboutManager.GetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            AboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
