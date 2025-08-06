using BusinessLayer.Concrete;
using CorePortfolio.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorePortfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel user)//tanımladığımız kısımları al
        {
            if (ModelState.IsValid) // geçerliyse 
            {
                WriterUser w = new WriterUser() //buradan gelenveriler nereden writer userdan writer user ile userregisterviewmodel eşleştir
                {
                    NameSurname = user.NameSurname,
                    Email = user.Mail,
                    ImageUrl = user.ImageUrl,
                    UserName = user.UserName
                };
                var result = await _userManager.CreateAsync(w, user.Password); // ve usermanagerda oluştur gelen verilen ve userdan gelen password
                if (result.Succeeded /*&& user.Password == user.ConfirmPassword*/)
                {
                    return RedirectToAction("Index", "Login");
                    //bunların hepsi başarıylıysa logindeki indexe gönder
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);// değilse error ver
                    }
                }

            }
           
                return View();
        }
    }
}
