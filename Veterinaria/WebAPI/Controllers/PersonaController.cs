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
                return Lista;
            }
        }

        [HttpGet("{nombrePersona}")]
        public List<PersonaCLS> ListarPersona(string nombrePersona)
        {
            List<PersonaCLS> Lista = new List<PersonaCLS>();

            try
            {
                using (DbAa529bDbveterinariaContext db = new DbAa529bDbveterinariaContext())
                {
                    Lista = (from persona in db.Personas
                             where persona.Bhabilitado == 1 && (persona.Nombre + persona.Appaterno + persona.Apmaterno).Contains(nombrePersona)
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
                return Lista;
            }
        }

        [HttpGet("MostrarPersonaPorId/{id}")]
        public PersonaCLS ListarPersonaPorId(int id)
        {
            PersonaCLS oPersona = new PersonaCLS();

            try
            {
                using (DbAa529bDbveterinariaContext db = new DbAa529bDbveterinariaContext())
                {
                    oPersona = (from persona in db.Personas
                             where persona.Bhabilitado == 1 && persona.Iidpersona == id
                             select new PersonaCLS
                             {
                                 iid = persona.Iidpersona,
                                 nombre = persona.Nombre, 
                                 apellidoPaterno = persona.Appaterno,
                                 apellidoMaterno = persona.Apmaterno,
                                 correo = persona.Correo,
                                 iidsexo = (int)persona.Iidsexo,
                                 fechaNacimiento = (DateTime)persona.Fechanacimiento,
                                 fechaNacimientoCadena = persona.Fechanacimiento == null ? "" : persona.Fechanacimiento.Value.ToString("dd/MM/yyyy")
                             }).First();
                    return oPersona;
                }
            }
            catch (Exception)
            {
                return oPersona;
            }
        }
    }
}
