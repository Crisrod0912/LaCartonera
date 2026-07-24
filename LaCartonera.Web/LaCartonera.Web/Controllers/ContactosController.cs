using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class ContactosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
