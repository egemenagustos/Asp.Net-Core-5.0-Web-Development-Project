using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            var values = AnnouncementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Announcement announcement = AnnouncementManager.GetByID(id);
            return View(announcement);
        }
    }
}
