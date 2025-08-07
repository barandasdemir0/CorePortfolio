using BusinessLayer.Concrete;
using CorePortfolio.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.NameSurname = values.NameSurname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> Index(UserEditViewModel user)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.Picture !=   null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(user.Picture.FileName);
                var imageName = Guid.NewGuid()+ extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await user.Picture.CopyToAsync(stream);
                values.ImageUrl = imageName;
            }
            values.NameSurname = user.NameSurname;
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index","Default","Writer");
            }
            return View();
        }
    }
}
