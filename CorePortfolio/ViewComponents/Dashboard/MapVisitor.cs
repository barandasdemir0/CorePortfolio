using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class MapVisitor: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
