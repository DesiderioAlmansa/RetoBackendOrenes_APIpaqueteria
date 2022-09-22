using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Infrastructura.Datos.Context;

namespace RetoBackendOrenes.Infrastructura.Datos.Repositorios
{
    public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {
        private RetoContext _db;

        public ClienteRepositorio(RetoContext db)
        {
            this._db = db;
        }

        public Cliente Agregar(Cliente entidad)
        {
            entidad.clienteId = Guid.NewGuid();
            this._db.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad)
        {
            var clienteSeleccionado = this._db.Clientes.Where(c => c.clienteId == entidad.clienteId).FirstOrDefault();
            if(clienteSeleccionado != null)
            {
                clienteSeleccionado.nombre = entidad.nombre;
                clienteSeleccionado.correo = entidad.correo;
                clienteSeleccionado.telefono = entidad.telefono;

                this._db.Entry(clienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//enmarca el estado de la entidad en modificado
            }
            else
            {
                throw new NullReferenceException("El Cliente no existe");
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var clienteSeleccionado = this._db.Clientes.Where(c => c.clienteId == entidadID).FirstOrDefault();
            if (clienteSeleccionado != null)
            {

                this._db.Remove(clienteSeleccionado);
            }
            else
            {
                throw new NullReferenceException("El Cliente no existe");
            }
        }

        public void GuardarTodosLosCambios()
        {
            this._db.SaveChanges(); 
        }

        public List<Cliente> Listar()
        {
            return this._db.Clientes.ToList();
        }

        public Cliente SeleccionarPorID(Guid entidadID)
        {
            var clienteSeleccionado = this._db.Clientes.Where(c => c.clienteId == entidadID).FirstOrDefault();
            return clienteSeleccionado;
        }
    }
}
