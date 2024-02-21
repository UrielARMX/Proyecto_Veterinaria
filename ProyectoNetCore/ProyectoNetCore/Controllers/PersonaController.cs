using Microsoft.AspNetCore.Mvc;

namespace ProyectoNetCore.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
