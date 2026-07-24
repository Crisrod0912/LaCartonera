using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
