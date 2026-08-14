using LaCartonera.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCartonera.Web.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public ReservasController(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Reservas/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<ReservasModel>>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpGet]
        public IActionResult VerReservasPorLocal(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/" + id + "/Reservas";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<LocalConReservasModel>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        public IActionResult CrearReserva(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Usuarios/0";
                var responseUsuarios = http.GetAsync(url).Result;

                if (responseUsuarios.IsSuccessStatusCode)
                {
                    var usuarios = responseUsuarios.Content.ReadFromJsonAsync<List<UsuariosModel>>().Result;
                    var usuariosSelectList = new SelectList(usuarios, "_id", "nombre");

                    ViewBag.Usuarios = usuariosSelectList;
                }

                var modelo = new ReservasModel
                {
                    IdLocal = id
                };

                return View(modelo);
            }
        }

        [HttpPost]
        public IActionResult CrearReserva(ReservasModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Varaiables:urlWebApi").Value + "Reservas";
                var response = http.PostAsJsonAsync(url, model).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Locales");
                }

                return RedirectToAction("Index", "Locales");
            }
        }

        public IActionResult VerReservas(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Reservas" + id;
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<ReservasModel>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpPost]
        public IActionResult EditarReserva(ReservasModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Reservas/" + model._id;
                var response = http.PutAsJsonAsync(url, model).Result;

                return RedirectToAction("Index", "Locales");
            }
        }

        [HttpPost]
        public IActionResult EliminarReserva(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Reservas/" + id;
                var response = http.DeleteAsync(url).Result;

                return RedirectToAction("Index", "Locales");
            }
        }
    }
}
