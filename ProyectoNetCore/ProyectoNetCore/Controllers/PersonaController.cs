using Microsoft.AspNetCore.Mvc;

namespace ProyectoNetCore.Controllers
{
    public class PersonaController : Controller
    {
        private string _baseurl;

        public PersonaController(IConfiguration configuration)
        {
            _baseurl = configuration["baseurl"];
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
