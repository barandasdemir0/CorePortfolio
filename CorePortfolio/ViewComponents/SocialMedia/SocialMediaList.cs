using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.SocialMedia
{
    public class SocialMediaList: ViewComponent
    {
       SocialMediaManager smm = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
           var values = smm.TGetList();
            return View(values);
        }
    }
}
