using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.d1 = c.Skills.Count();
            ViewBag.d2 = c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.d3 = c.Messages.Where(x=>x.Status==true).Count();
            ViewBag.d4 = c.Experiences.Count();
            return View();
        }
    }
}
