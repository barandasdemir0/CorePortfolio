using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorePortfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;
        Context context = new Context();

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("Receivermessage")]
        public async Task<IActionResult> Receivermessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        [Route("")]
        [Route("Sendermessage")]
        public async Task<IActionResult> Sendermessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }

        [Route("")]
        [Route("AddMessage")]
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [Route("")]
        [Route("AddMessage")]
        [HttpPost]
        public async Task< IActionResult> AddMessage(WriterMessage message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.NameSurname;
            var value = context.Users.Where(x=>x.Email ==  message.MessageReceiver).Select(y=>y.NameSurname).FirstOrDefault();
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageSender = mail;
            message.MessageSenderName = name;
            message.MessageReceiverName = value;
             writerMessageManager.TAdd(message);
            return RedirectToAction("Sendermessage");
        }




    }
}
