using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(5).ToList();


            ViewBag.picture = context.WriterMessages.Join(context.Users, m => m.MessageSender, u => u.Email, (m, u) => u.ImageUrl).Distinct();
           



            return View(values);
        }
    }
}
