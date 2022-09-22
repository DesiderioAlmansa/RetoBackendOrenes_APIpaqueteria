using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Infrastructura.Datos.Context;

namespace RetoBackendOrenes.Infrastructura.Datos.Repositorios
{
    public class ConductorRepositorio : IRepositorioBase<Conductor, Guid>
    {
        private RetoContext _db;

        public ConductorRepositorio(RetoContext db)
        {
            this._db = db;
        }

        public Conductor Agregar(Conductor entidad)
        {
            entidad.conductorId = Guid.NewGuid();
            this._db.Conductor.Add(entidad);
            return entidad;
        }

        public void Editar(Conductor entidad)
        {
            var conductorSeleccionado = this._db.Conductor.Where(c => c.conductorId == entidad.conductorId).FirstOrDefault();
            if (conductorSeleccionado != null)
            {
                conductorSeleccionado.nombre = entidad.nombre;
                conductorSeleccionado.telefono = entidad.telefono;
                conductorSeleccionado.carnetCirculacion = entidad.carnetCirculacion;

                this._db.Entry(conductorSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//enmarca el estado de la entidad en modificado
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var conductorSeleccionado = this._db.Conductor.Where(c => c.conductorId == entidadID).FirstOrDefault();
            if (conductorSeleccionado != null)
            {

                this._db.Remove(conductorSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            this._db.SaveChanges();
        }

        public List<Conductor> Listar()
        {
            return this._db.Conductor.ToList();
        }

        public Conductor SeleccionarPorID(Guid entidadID)
        {
            var conductorSeleccionado = this._db.Conductor.Where(c => c.conductorId == entidadID).FirstOrDefault();
            return conductorSeleccionado;
        }
    }
}
