using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Aplicacion.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Servicios
{
    public class ClienteServicio : IServicioBase<Cliente, Guid>
    {

        private readonly IRepositorioBase<Cliente, Guid> _repoCliente;

        public ClienteServicio(IRepositorioBase<Cliente, Guid> repoCliente)
        {
            this._repoCliente = repoCliente;
        }

        public Cliente Agregar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Cliente' es requerido.");


            var resultadoCliente = this._repoCliente.Agregar(entidad);

            this._repoCliente.GuardarTodosLosCambios();
            return resultadoCliente;

        }

        public void Editar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Cliente' es requerido.");

            this._repoCliente.Editar(entidad);
            this._repoCliente.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadID)
        {
            this._repoCliente.Eliminar(entidadID);
            this._repoCliente.GuardarTodosLosCambios();
        }

        public List<Cliente> Listar()
        {
            return this._repoCliente.Listar();
        }

        public Cliente SeleccionarPorID(Guid entidadID)
        {
            return this._repoCliente.SeleccionarPorID(entidadID);
        }
    }
}
