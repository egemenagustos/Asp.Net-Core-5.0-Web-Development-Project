using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessage = new WriterMessageManager(new EfWriterMessageDal());

        public IActionResult ReceiverMessageList()
        {
            TempData["DeleteUrl"] = "ReceiverMessageList";
            string p = "egemen@test.com";
            var values = writerMessage.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            TempData["DeleteUrl"] = "SenderMessageList";
            string p = "egemen@test.com";
            var values = writerMessage.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetail(int id)
        {
            var values = writerMessage.GetByID(id);
            return View(values);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            string ViewUrl = TempData["DeleteUrl"].ToString();
            var values = writerMessage.GetByID(id);
            writerMessage.TDelete(values);
            return RedirectToAction(ViewUrl);
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + "" + y.SurName).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessage.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
