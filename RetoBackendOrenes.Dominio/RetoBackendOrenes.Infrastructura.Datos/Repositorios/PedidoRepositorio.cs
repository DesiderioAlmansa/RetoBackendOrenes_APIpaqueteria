using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Infrastructura.Datos.Context;

namespace RetoBackendOrenes.Infrastructura.Datos.Repositorios
{
    public class PedidoRepositorio : IRepositorioBase<Pedido, Guid>
    {
        private RetoContext _db;

        public PedidoRepositorio(RetoContext db)
        {
            this._db = db;
        }

        public Pedido Agregar(Pedido entidad)
        {
            entidad.numeroPedido = Guid.NewGuid();
            this._db.Pedido.Add(entidad);
            return entidad;
        }

        public void Editar(Pedido entidad)
        {
            var pedidoSeleccionado = this._db.Pedido.Where(c => c.numeroPedido == entidad.numeroPedido).FirstOrDefault();
            if (pedidoSeleccionado != null)
            {
                if(entidad.direccionEnvio != null) pedidoSeleccionado.direccionEnvio = entidad.direccionEnvio;
                if(entidad.entregado != null) pedidoSeleccionado.entregado = entidad.entregado;

                if(!pedidoSeleccionado.vehiculoId.Equals(entidad.vehiculoId)){

                    var vehiculo = this._db.Vehiculo.Where(v => v.vehiculoId == entidad.vehiculoId).FirstOrDefault();
                    if(vehiculo!= null)
                    {
                        pedidoSeleccionado.vehiculoId = entidad.vehiculoId;
                    }
                    else
                    {
                        throw new NullReferenceException("Se pretende asignar un Vehiculo que no existe.");
                    }
                }

                this._db.Entry(pedidoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//enmarca el estado de la entidad en modificado
            }
            else
            {
                throw new NullReferenceException("El Pedido no existe");
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var pedidoSeleccionado = this._db.Pedido.Where(c => c.numeroPedido == entidadID).FirstOrDefault();
            if (pedidoSeleccionado != null)
            {
                this._db.Remove(pedidoSeleccionado);
            }
            else
            {
                throw new NullReferenceException("El Pedido no existe");
            }
        }

        public void GuardarTodosLosCambios()
        {
            this._db.SaveChanges();
        }

        public List<Pedido> Listar()
        {
            return this._db.Pedido.ToList();
        }

        public Pedido SeleccionarPorID(Guid entidadID)
        {
            var pedidoSeleccionado = this._db.Pedido.Where(c => c.numeroPedido == entidadID).FirstOrDefault();
            return pedidoSeleccionado;
        }
    }
}