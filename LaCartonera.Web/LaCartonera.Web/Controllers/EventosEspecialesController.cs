using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class EventosEspecialesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
