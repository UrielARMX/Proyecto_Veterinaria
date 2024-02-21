using Microsoft.AspNetCore.Mvc;

namespace ProyectoNetCore.Controllers
{
    public class PersonaController : Controller
    {
        private string _baseurl;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _baseurl = configuration["baseurl"];
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
