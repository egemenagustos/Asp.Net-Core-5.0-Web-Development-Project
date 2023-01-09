using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = contactManager.GetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            contactManager.TUpdate(p);
            return RedirectToAction("Index","Default");
        }
    }
}
