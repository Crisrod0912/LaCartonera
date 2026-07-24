using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class LocalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
