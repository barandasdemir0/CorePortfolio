using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

     
        public IViewComponentResult Invoke()
        {
            return View();
        }
        //[HttpPost]
        //public IViewComponentResult Invoke(Message message)
        //{
        //    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    message.Status = true; // Assuming you want to set the status to true when sending a message
        //    messageManager.TAdd(message);
        //    return View();
        //}
    }
}
