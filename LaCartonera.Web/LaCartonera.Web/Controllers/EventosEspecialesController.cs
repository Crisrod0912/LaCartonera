using LaCartonera.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaCartonera.Web.Controllers
{
    public class EventosEspecialesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public EventosEspecialesController(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "EventosEspeciales/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<EventosEspecialesModel>>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        public IActionResult CrearEventosEspeciales()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/0";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var usuarios = response.Content.ReadFromJsonAsync<List<LocalesModel>>().Result;
                    var localesSelectList = new SelectList(usuarios, "_id", "nombre");

                    ViewBag.Locales = localesSelectList;
                }

                return View();
            }
        }

        [HttpPost]
        public IActionResult CrearEventosEspeciales(EventosEspecialesModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("´Variables:urlWebApi").Value + "EventosEspeciales";
                var response = http.PostAsJsonAsync(url, model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "EventosEspeciales");
                }

                return RedirectToAction("Index", "EventosEspeciales");
            }
        }

        public IActionResult VerEventosEspeciales(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "EventosEspeciales/" + id;
                var responseEvento = http.GetAsync(url).Result;

                if (responseEvento.IsSuccessStatusCode)
                {
                    var result = responseEvento.Content.ReadFromJsonAsync<EventosEspecialesModel>().Result;
                    var urlLocales = _configuration.GetSection("Variables:urlWebApi").Value + "Locales/0";
                    var responseLocales = http.GetAsync(urlLocales).Result;

                    if (responseLocales.IsSuccessStatusCode)
                    {
                        var locales = responseLocales.Content.ReadFromJsonAsync<List<LocalesModel>>().Result;
                        var localesSelectList = new SelectList(locales, "_id", "nombre");

                        ViewBag.Locales = localesSelectList;
                    }

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpPost]
        public IActionResult EditarEventosEspeciales(EventosEspecialesModel model)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "EventosEspeciales/" + model._id;
                var response = http.PutAsJsonAsync(url, model).Result;

                return RedirectToAction("Index", "EventosEspeciales");
            }
        }

        [HttpPost]
        public IActionResult EliminarEventosEspeciales(int id)
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "EventosEspeciales/" + id;
                var response = http.DeleteAsync(url).Result;

                return RedirectToAction("Index", "EventosEspeciales");
            }
        }
    }
}
