using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Aplicacion.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Servicios
{
    class LogCambiosUbicacionServicio : IServicioBase<LogCambiosUbicacion, Guid>
    {
        private readonly IRepositorioBase<Vehiculo, Guid> _repoVehiculo;
        private readonly IRepositorioBase<LogCambiosUbicacion, Guid> _repoLogCambiosUbicacion;
      

        public LogCambiosUbicacionServicio(IRepositorioBase<Vehiculo, Guid> repoVehiculo, IRepositorioBase<LogCambiosUbicacion, Guid> repoLogCambiosUbicacion)
        {
            this._repoVehiculo = repoVehiculo;
            this._repoLogCambiosUbicacion = repoLogCambiosUbicacion;

        }

        public LogCambiosUbicacion Agregar(LogCambiosUbicacion entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'LogCambiosUbicacion' es requerido.");

            var resultadoLogCambiosUbicacion = this._repoLogCambiosUbicacion.Agregar(entidad);

            var vehiculo = this._repoVehiculo.SeleccionarPorID(entidad.vehiculoId);
            if (vehiculo == null)
                throw new NullReferenceException("El vehiculo no existe en la base de datos.");

            this._repoLogCambiosUbicacion.GuardarTodosLosCambios();
            return resultadoLogCambiosUbicacion;

        }

        public void Editar(LogCambiosUbicacion entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'LogCambiosUbicacion' es requerido.");

            this._repoLogCambiosUbicacion.Editar(entidad);
            this._repoLogCambiosUbicacion.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadID)
        {
            this._repoLogCambiosUbicacion.Eliminar(entidadID);
            this._repoLogCambiosUbicacion.GuardarTodosLosCambios();
        }

        public List<LogCambiosUbicacion> Listar()
        {
            return this._repoLogCambiosUbicacion.Listar();
        }

        public LogCambiosUbicacion SeleccionarPorID(Guid entidadID)
        {
            return this._repoLogCambiosUbicacion.SeleccionarPorID(entidadID);
        }
    }
}