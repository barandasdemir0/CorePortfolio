using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CorePortfolio.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EfWriterDal());
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult GetWriterUserList()
        {
            var users = JsonConvert.SerializeObject(userManager.TGetList());
            return Json(users);
        }
    }
}
