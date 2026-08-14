using LaCartonera.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCartonera.Web.Controllers
{
    public class LocalesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public LocalesController(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<LocalesModel>>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        public IActionResult CrearLocal()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Categorias/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var categorias = response.Content.ReadFromJsonAsync<List<CategoriasModel>>().Result;
                    var categoriaSelectList = new SelectList(categorias, "Nombre", "Nombre");

                    ViewBag.Categorias = categoriaSelectList;
                }

                return View();
            }
        }

        [HttpPost]
        public IActionResult CrearLocal(LocalesModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales";
                var response = http.PostAsJsonAsync(url, model).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Locales");
                }

                return RedirectToAction("Index", "Locales");
            }
        }

        public IActionResult VerLocal(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var urlLocal = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/" + id;
                var responseLocal = http.GetAsync(urlLocal).Result;

                if (responseLocal.IsSuccessStatusCode)
                {
                    var local = responseLocal.Content.ReadFromJsonAsync<LocalesModel>().Result;
                    var urlCategorias = _configuration.GetSection("Variables:urlWebApi").Value + "Categorias/0";
                    var responseCategorias = http.GetAsync(urlCategorias).Result;

                    if (responseCategorias.IsSuccessStatusCode)
                    {
                        var categorias = responseCategorias.Content.ReadFromJsonAsync<List<CategoriasModel>>().Result;
                        var categoriaSelectList = new SelectList(categorias, "Nombre", "Nombre", local.categoria);

                        ViewBag.Categorias = categoriaSelectList;

                        return View(local);
                    }
                }

                return View(null);
            }
        }

        [HttpPost]
        public IActionResult EditarLocal(LocalesModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/" + model._id;
                var response = http.PutAsJsonAsync(url, model).Result;

                return RedirectToAction("Index", "Locales");
            }
        }

        [HttpPost]
        public IActionResult EliminarLocal(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/" + id;
                var response = http.DeleteAsync(url).Result;

                return RedirectToAction("Index", "Locales");
            }
        }
    }
}
