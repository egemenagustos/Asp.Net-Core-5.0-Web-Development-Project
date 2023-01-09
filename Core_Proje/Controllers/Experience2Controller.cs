using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var v = experienceManager.GetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.GetByID(id);
            experienceManager.TDelete(v);
            return NoContent(); // geriye hiçbir şey döndürme...
        }

        public IActionResult EditExperience(int ExperienceID, string Name, string Date)
        {
            var v = experienceManager.GetByID(ExperienceID);
            if(v != null)
            {
            v.Name = Name;
            v.Date = Date;
            experienceManager.TUpdate(v);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
            }
            else
            {
                return Json(new object());
            }
        }
    }
}
