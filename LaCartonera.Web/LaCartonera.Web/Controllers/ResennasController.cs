using LaCartonera.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCartonera.Web.Controllers
{
    public class ResennasController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public ResennasController(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Resennas/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<ResennasModel>>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpGet]
        public IActionResult VerResennasPorLocal(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/" + id + "Resennas";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<LocalConResennasModel>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        public IActionResult CrearResenna(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Usuarios/0";
                var responseUsuarios = http.GetAsync(url).Result;

                if (responseUsuarios.IsSuccessStatusCode)
                {
                    var usuarios = responseUsuarios.Content.ReadFromJsonAsync<List<UsuariosModel>>().Result;
                    var usuarioSelectList = new SelectList(usuarios, "_id", "nombre");

                    ViewBag.Usuarios = usuarioSelectList;
                }

                var modelo = new ResennasModel
                {
                    IdLocal = id
                };

                return View(modelo);
            }
        }

        [HttpPost]
        public IActionResult CrearResenna(ResennasModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Resennas";
                var response = http.PostAsJsonAsync(url, model).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Locales");
                }

                return RedirectToAction("Index", "Locales");
            }
        }

        public IActionResult VerResenna(int id)
        {
            using (var httpp = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Resennas/" + id;
                var response = httpp.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<ResennasModel>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpPost]
        public IActionResult EditarResenna(ResennasModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Resennas/" + model._id;
                var response = http.PutAsJsonAsync(url, model).Result;

                return RedirectToAction("Index", "Locales");
            }
        }

        [HttpPost]
        public IActionResult EliminarResenna(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Resennas/" + id;
                var response = http.DeleteAsync(url).Result;

                return RedirectToAction("Index", "Locales");
            }
        }
    }
}
