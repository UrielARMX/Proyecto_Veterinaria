using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public List<PersonaCLS> ListarPersonas()
        {
            List<PersonaCLS> Lista = new List<PersonaCLS>();

            try
            {
                using (DbAa529bDbveterinariaContext db = new DbAa529bDbveterinariaContext())
                {
                    Lista = (from persona in db.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaCLS
                             {
                                 iid = persona.Iidpersona,
                                 nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechaNacimientoCadena = persona.Fechanacimiento == null ? "" : persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                             }).ToList();
                    return Lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
