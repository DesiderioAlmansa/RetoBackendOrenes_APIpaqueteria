using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Aplicacion.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Servicios
{
    public class ConductorServicio : IServicioBase<Conductor, Guid>
    {
        private readonly IRepositorioBase<Conductor, Guid> _repoConductor;

        public ConductorServicio(IRepositorioBase<Conductor, Guid> repoConductor)
        {
            this._repoConductor = repoConductor;
        }

        public Conductor Agregar(Conductor entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Conductor' es requerido.");


            var resultadoConductor = this._repoConductor.Agregar(entidad);
            this._repoConductor.GuardarTodosLosCambios();
            return resultadoConductor;

        }

        public void Editar(Conductor entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Conductor' es requerido.");

            this._repoConductor.Editar(entidad);
            this._repoConductor.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadID)
        {
            this._repoConductor.Eliminar(entidadID);
            this._repoConductor.GuardarTodosLosCambios();
        }

        public List<Conductor> Listar()
        {
            return this._repoConductor.Listar();
        }

        public Conductor SeleccionarPorID(Guid entidadID)
        {
            return this._repoConductor.SeleccionarPorID(entidadID);
        }
    }
}
