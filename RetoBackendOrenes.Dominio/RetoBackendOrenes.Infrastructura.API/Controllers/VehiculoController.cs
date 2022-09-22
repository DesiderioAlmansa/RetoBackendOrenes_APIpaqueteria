﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/vehiculo")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        VehiculoServicio CrearServicioVehiculo()
        {
            RetoContext db = new RetoContext();
            
            VehiculoRepositorio repoVehiculos = new VehiculoRepositorio(db);
            ConductorRepositorio repoPedidos = new ConductorRepositorio(db);
            VehiculoServicio servicioVehiculo = new VehiculoServicio(repoVehiculos, repoPedidos);

            return servicioVehiculo;
        }

        // GET: api/vehiculo/getall
        [Route("getall")]
        [HttpGet]
        public ActionResult<List<Vehiculo>> Get()
        {
            var servicio = CrearServicioVehiculo();
            return Ok(servicio.Listar());
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehiculo> Get(Guid id)
        {
            var servicio = CrearServicioVehiculo();
            return Ok(servicio.SeleccionarPorID(id));
        }


        // POST api/<VehiculoController>
        [Route("agregar")]
        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo nuevoVehiculo)
        {

            var servicio = CrearServicioVehiculo();
            servicio.Agregar(nuevoVehiculo);
            return Ok("Se ha insertado el Cliente satisfactoriamente.");
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Vehiculo editVehiculo)
        {
            var servicio = CrearServicioVehiculo();
            editVehiculo.vehiculoId = id;
            servicio.Editar(editVehiculo);
            return Ok("Se ha editado el Cliente satisfactoriamente.");
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicioVehiculo();
            servicio.Eliminar(id);
            return Ok("Se ha eliminado el Cliente satisfactoriamente.");
        }
    }
}
