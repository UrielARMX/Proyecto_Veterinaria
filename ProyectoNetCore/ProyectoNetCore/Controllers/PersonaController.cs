using Microsoft.AspNetCore.Mvc;
using CapaEntidad;

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

        public async Task<string> ListarPersona()
        {
            var cliente = _httpClientFactory.CreateClient();
            cliente.BaseAddress = new Uri(_baseurl);
            string respuesta = await cliente.GetStringAsync("/api/Persona");
            return respuesta;
        }
    }
}
