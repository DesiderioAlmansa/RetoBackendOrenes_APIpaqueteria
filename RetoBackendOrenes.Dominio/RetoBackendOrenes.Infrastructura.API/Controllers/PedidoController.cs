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
        VehiculoServicio CrearServicioVehiculo()
        {
            RetoContext db = new RetoContext();

            VehiculoRepositorio repoVehiculos = new VehiculoRepositorio(db);
            ConductorRepositorio repoPedidos = new ConductorRepositorio(db);
            VehiculoServicio servicioVehiculo = new VehiculoServicio(repoVehiculos, repoPedidos);

            return servicioVehiculo;
        }

        // GET: api/pedido/getall
        [Route("getall")]
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var servicio = CrearServicioPedido();
            return Ok(servicio.Listar());
        }

        // GET api/pedido/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(Guid id)
        {
            var servicio = CrearServicioPedido();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // GET api/pedido/5
        [HttpGet("obtenerVehiculo/{numPedido}")]
        public ActionResult<Vehiculo> GetVehiculo(Guid numPedido)
        {
            var servicioPedido = CrearServicioPedido();
            var pedido = servicioPedido.SeleccionarPorID(numPedido);

            var servicioVehiculo = CrearServicioVehiculo();
            return Ok(servicioVehiculo.SeleccionarPorID(pedido.vehiculoId));
        }

        // POST api/pedido/
        [HttpPost]
        public ActionResult Post([FromBody] Pedido nuevoPedido)
        {
            var servicio = CrearServicioPedido();
            servicio.Agregar(nuevoPedido);
            return Ok("Se ha insertado el Pedido satisfactoriamente.");
        }

        // PUT api/pedido/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido editPedido)
        {
            var servicio = CrearServicioPedido();
            editPedido.clienteId = id;
            servicio.Editar(editPedido);
            return Ok("Se ha editado el Pedido satisfactoriamente.");
        }

      
        // PUT api/pedido/asignarVehiculo/{numPedido}/{idVehiculo}
        [HttpPut("asignarVehiculo/{numPedido}/{idVehiculo}")]
        public ActionResult Put(Guid numPedido, Guid idVehiculo)
        {
            var servicio = CrearServicioPedido();
            var pedidoSeleccionado = servicio.SeleccionarPorID(numPedido);

            var editPedido = new Pedido();
            editPedido.numeroPedido = pedidoSeleccionado.numeroPedido;
            editPedido.vehiculoId = idVehiculo;

            servicio.Editar(editPedido);
            return Ok("Se ha asignado el Vehiculo al Pedido satisfactoriamente.");
        }

        // DELETE api/pedido/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioPedido();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Pedido satisfactoriamente.");
        }
    }
}
