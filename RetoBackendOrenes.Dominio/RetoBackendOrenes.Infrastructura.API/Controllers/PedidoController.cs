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
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        PedidoServicio CrearServicioPedido()
        {
            RetoContext db = new RetoContext();
            PedidoRepositorio repoPedidos = new PedidoRepositorio(db);
            ClienteRepositorio repoClientes = new ClienteRepositorio(db);
            VehiculoRepositorio repoVehiculos = new VehiculoRepositorio(db);
            PedidoServicio servicioPedido = new PedidoServicio(repoPedidos, repoClientes, repoVehiculos);

            return servicioPedido;
        }

        // GET: api/pedido/getall
        [Route("getall")]
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var servicio = CrearServicioPedido();
            return Ok(servicio.Listar());
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(Guid id)
        {
            var servicio = CrearServicioPedido();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/pedido/
        [Route("agregar")]
        [HttpPost]
        public ActionResult Post([FromBody] Pedido nuevoPedido)
        {
            var servicio = CrearServicioPedido();
            servicio.Agregar(nuevoPedido);
            return Ok("Se ha insertado el Pedido satisfactoriamente.");
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido editPedido)
        {
            var servicio = CrearServicioPedido();
            editPedido.clienteId = id;
            servicio.Editar(editPedido);
            return Ok("Se ha editado el Pedido satisfactoriamente.");
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioPedido();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Pedido satisfactoriamente.");
        }
    }
}
