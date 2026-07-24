using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class MenusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
