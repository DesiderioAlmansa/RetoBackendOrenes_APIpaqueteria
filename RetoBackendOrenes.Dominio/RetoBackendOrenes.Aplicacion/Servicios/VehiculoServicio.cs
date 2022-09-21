using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Aplicacion.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Servicios
{
    public class VehiculoServicio : IServicioBase<Vehiculo, Guid>
    {
        private readonly IRepositorioBase<Vehiculo, Guid> _repoVehiculo;
        private readonly IRepositorioBase<Conductor, Guid> _repoConductor;
        //private readonly IRepositorioBase<Pedido, Guid> _repoPedido;
        //private readonly IRepositorioBase<LogCambiosUbicacion, Guid> _repoLogCambiosUbicacion;

        public VehiculoServicio(IRepositorioBase<Vehiculo, Guid> repoVehiculo, IRepositorioBase<Conductor, Guid> repoConductor/*IRepositorioBase<Pedido, Guid> repoPedido, 
            IRepositorioBase<LogCambiosUbicacion, Guid> repoLogCambiosUbicacion*/)
        {
            this._repoVehiculo = repoVehiculo;
            this._repoConductor = repoConductor;
            //this._repoPedido = repoPedido;
            //this._repoLogCambiosUbicacion = repoLogCambiosUbicacion;
        }

        public Vehiculo Agregar(Vehiculo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Vehiculo' es requerido.");

            var resultadoVehiculo = this._repoVehiculo.Agregar(entidad);

            var conductor = this._repoConductor.SeleccionarPorID(entidad.conductorId);
            if (conductor == null)
                throw new NullReferenceException("El conductor no existe en la base de datos.");

            this._repoVehiculo.GuardarTodosLosCambios();
            return resultadoVehiculo;

        }

        public void Editar(Vehiculo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Vehiculo' es requerido.");

            this._repoVehiculo.Editar(entidad);
            this._repoVehiculo.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadID)
        {
            this._repoVehiculo.Eliminar(entidadID);
            this._repoVehiculo.GuardarTodosLosCambios();
        }

        public List<Vehiculo> Listar()
        {
            return this._repoVehiculo.Listar();
        }

        public Vehiculo SeleccionarPorID(Guid entidadID)
        {
            return this._repoVehiculo.SeleccionarPorID(entidadID);
        }
    }
}