using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Infrastructura.Datos.Context;

namespace RetoBackendOrenes.Infrastructura.Datos.Repositorios
{
    public class VehiculoRepositorio : IRepositorioBase<Vehiculo, Guid>
    {
        private RetoContext _db;

        public VehiculoRepositorio(RetoContext db)
        {
            this._db = db;
        }

        public Vehiculo Agregar(Vehiculo entidad)
        {
            entidad.vehiculoId = Guid.NewGuid();
            this._db.Vehiculo.Add(entidad);
            return entidad;
        }

        public void Editar(Vehiculo entidad)
        {
            var vehiculoSeleccionado = this._db.Vehiculo.Where(c => c.vehiculoId == entidad.vehiculoId).FirstOrDefault();
            if (vehiculoSeleccionado != null)
            {
                vehiculoSeleccionado.pedidosPendientes = entidad.pedidosPendientes;
                vehiculoSeleccionado.ubicacionActual = entidad.ubicacionActual;

                this._db.Entry(vehiculoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//enmarca el estado de la entidad en modificado
            }
            else
            {
                throw new NullReferenceException("El Vehiculo no existe");
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var vehiculoSeleccionado = this._db.Vehiculo.Where(c => c.vehiculoId == entidadID).FirstOrDefault();
            if (vehiculoSeleccionado != null)
            {

                this._db.Remove(vehiculoSeleccionado);
            }
            else
            {
                throw new NullReferenceException("El Vehiculo no existe");
            }
        }

        public void GuardarTodosLosCambios()
        {
            this._db.SaveChanges();
        }

        public List<Vehiculo> Listar()
        {
            return this._db.Vehiculo.ToList();
        }

        public Vehiculo SeleccionarPorID(Guid entidadID)
        {
            var vehiculoSeleccionado = this._db.Vehiculo.Where(c => c.vehiculoId == entidadID).FirstOrDefault();
            return vehiculoSeleccionado;
        }
    }
}