using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class FotosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
