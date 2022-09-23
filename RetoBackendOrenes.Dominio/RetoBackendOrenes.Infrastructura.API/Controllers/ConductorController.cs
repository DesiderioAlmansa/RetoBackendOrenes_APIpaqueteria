using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Aplicacion.Servicios;
using RetoBackendOrenes.Infrastructura.Datos.Context;
using RetoBackendOrenes.Infrastructura.Datos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetoBackendOrenes.Infrastructura.API.Controllers
{
    [Route("api/conductor")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        ConductorServicio CrearServicioConductor()
        {
            RetoContext db = new RetoContext();
            ConductorRepositorio repoConductores = new ConductorRepositorio(db);
            ConductorServicio servicioConductor = new ConductorServicio(repoConductores);

            return servicioConductor;
        }

        // GET: api/conductor/getall
        [Route("getall")]
        [HttpGet]
        public ActionResult<List<Conductor>> Get()
        {
            var servicio = CrearServicioConductor();
            return Ok(servicio.Listar());
        }

        // GET api/conductor/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var servicio = CrearServicioConductor();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/conductor
        [HttpPost]
        public ActionResult Post([FromBody] Conductor nuevoConductor)
        {
            var servicio = CrearServicioConductor();
            servicio.Agregar(nuevoConductor);
            return Ok("Se ha insertado el Conductor satisfactoriamente.");
        }

        // PUT api/conductor/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Conductor editConductor)
        {
            var servicio = CrearServicioConductor();
            editConductor.conductorId = id;
            servicio.Editar(editConductor);
            return Ok("Se ha editado el Conductor satisfactoriamente.");
        }

        // DELETE api/conductor/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioConductor();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Conductor satisfactoriamente.");
        }
    }
}
