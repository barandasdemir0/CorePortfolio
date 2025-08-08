using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CorePortfolio.Controllers
{
    public class AdminMesajController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(p);  
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListSenderMessage(p);  
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageSend()
        {
          return View();
        }
        [HttpPost]
        public IActionResult MessageSend(WriterMessage message)
        {
            message.MessageSender = "admin@gmail.com";
            message.MessageSenderName = "admin";
            message.MessageDate = DateTime.Parse( DateTime.Now.ToShortDateString());
            messageManager.TAdd(message);
            return RedirectToAction("SenderMessageList");
        }
    }
}
