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
    [Route("api/logcambiosubicacion")]
    [ApiController]
    public class LogCambiosUbicacionesController : ControllerBase
    {
        LogCambiosUbicacionServicio CrearServicioLogCambiosUbicacion()
        {
            RetoContext db = new RetoContext();
            LogCambiosUbicacionRepositorio repoLogCambiosUbicacion = new LogCambiosUbicacionRepositorio(db);
            VehiculoRepositorio repoVehiculos = new VehiculoRepositorio(db);
            LogCambiosUbicacionServicio servicioLogCambiosUbicacion = new LogCambiosUbicacionServicio(repoVehiculos,repoLogCambiosUbicacion);

            return servicioLogCambiosUbicacion;
        }

        // GET: api/logcambiosubicacion/getall
        [Route("getall")]
        [HttpGet]
        public ActionResult<List<LogCambiosUbicacion>> Get()
        {
            var servicio = CrearServicioLogCambiosUbicacion();
            return Ok(servicio.Listar());
        }

        // GET api/<LogCambiosUbicacionesController>/5
        [HttpGet("{id}")]
        public ActionResult<LogCambiosUbicacion> Get(Guid id)
        {
            var servicio = CrearServicioLogCambiosUbicacion();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<LogCambiosUbicacionesController>
        [HttpPost]
        public ActionResult Post([FromBody] LogCambiosUbicacion nuevoLog)
        {
            var servicio = CrearServicioLogCambiosUbicacion();
            servicio.Agregar(nuevoLog);
            return Ok("Se ha insertado el Log satisfactoriamente.");
        }

        // PUT api/<LogCambiosUbicacionesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] LogCambiosUbicacion editLog)
        {
            var servicio = CrearServicioLogCambiosUbicacion();
            editLog.logId = id;
            servicio.Editar(editLog);
            return Ok("Se ha editado el Log satisfactoriamente.");
        }

        // DELETE api/<LogCambiosUbicacionesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioLogCambiosUbicacion();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Log satisfactoriamente.");
        }
    }
}
