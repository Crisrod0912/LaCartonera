using LaCartonera.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaCartonera.Web.Controllers
{
    public class VistaResennasController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public VistaResennasController(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "vista-resennas";
                var response = http.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<List<VistaResennasModel>>().Result;

                    return View(result);
                }

                return View(null);
            }
        }

        [HttpPost]
        public IActionResult ActualizarVista()
        {
            using (var http = _httpClient.CreateClient())
            {
                var url = _configuration.GetSection("Variables:urlWebApi").Value + "actualizar-vista";
                var response = http.PostAsync(url, null).Result;

                return RedirectToAction("Index", "VistaResennas");
            }
        }
    }
}
