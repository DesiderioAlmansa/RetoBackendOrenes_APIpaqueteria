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
            throw new NotImplementedException();
        }

        public void Editar(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid entidadID)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Listar()
        {
            throw new NotImplementedException();
        }

        public Cliente SeleccionarPorID(Guid entidadID)
        {
            throw new NotImplementedException();
        }
    }
}
