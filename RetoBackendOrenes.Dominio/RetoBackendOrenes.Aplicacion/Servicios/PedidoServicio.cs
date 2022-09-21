using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Aplicacion.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Servicios
{
    class PedidoServicio : IServicioBase<Pedido, Guid>
    {

        private readonly IRepositorioBase<Pedido, Guid> _repoPedido;
        private readonly IRepositorioBase<Cliente, Guid> _repoCliente;
        private readonly IRepositorioBase<Vehiculo, Guid> _repoVehiculo;

        public PedidoServicio(IRepositorioBase<Pedido, Guid> repoPedido, IRepositorioBase<Cliente, Guid> repoCliente, 
            IRepositorioBase<Vehiculo, Guid> repoVehiculo)
        {
            this._repoPedido = repoPedido;
            this._repoCliente = repoCliente;
            this._repoVehiculo = repoVehiculo;
        }

        public Pedido Agregar(Pedido entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Pedido' es requerido.");


            var resultadoPedido = this._repoPedido.Agregar(entidad);

            var cliente = this._repoCliente.SeleccionarPorID(entidad.clienteId);
            if (cliente == null)
                throw new NullReferenceException("El cliente no existe en la base de datos.");

            var vehiculo = this._repoVehiculo.SeleccionarPorID(entidad.Vehiculo.vehiculoId);
            if (vehiculo == null)
                throw new NullReferenceException("El vehiculo no existe en la base de datos.");


            this._repoPedido.GuardarTodosLosCambios();
            return resultadoPedido;
        }

        public void Editar(Pedido entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Pedido' es requerido.");

            this._repoPedido.Editar(entidad);
            this._repoPedido.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadID)
        {
            this._repoPedido.Eliminar(entidadID);
            this._repoPedido.GuardarTodosLosCambios();
        }

        public List<Pedido> Listar()
        {
            return this._repoPedido.Listar();
        }

        public Pedido SeleccionarPorID(Guid entidadID)
        {
            return this._repoPedido.SeleccionarPorID(entidadID);
        }
    }
}
