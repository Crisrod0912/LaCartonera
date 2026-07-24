using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class VistaResennasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
