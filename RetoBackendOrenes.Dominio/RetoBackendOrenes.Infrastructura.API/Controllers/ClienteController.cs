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
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteServicio CrearServicioCliente()
        {
            RetoContext db = new RetoContext();
            ClienteRepositorio repoClientes = new ClienteRepositorio(db);
            ClienteServicio servicioCliente = new ClienteServicio(repoClientes);

            return servicioCliente;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var servicio = CrearServicioCliente();
            return Ok(servicio.Listar());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            var servicio = CrearServicioCliente();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente nuevoCliente)
        {
            var servicio = CrearServicioCliente();
            servicio.Agregar(nuevoCliente);
            return Ok("Se ha insertado el Cliente satisfactoriamente.");
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cliente editCliente)
        {
            var servicio = CrearServicioCliente();
            editCliente.clienteId = id;
            servicio.Editar(editCliente);
            return Ok("Se ha editado el Cliente satisfactoriamente.");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioCliente();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Cliente satisfactoriamente.");
        }
    }
}
