using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class ReservasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
