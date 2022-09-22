using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RetoBackendOrenes.Dominio;
using RetoBackendOrenes.Dominio.Interfaces.Repositorios;
using RetoBackendOrenes.Infrastructura.Datos.Context;

namespace RetoBackendOrenes.Infrastructura.Datos.Repositorios
{
    public class LogCambiosUbicaionRepositorio : IRepositorioBase<LogCambiosUbicacion, Guid>
    {
        private RetoContext _db;

        public LogCambiosUbicaionRepositorio(RetoContext db)
        {
            this._db = db;
        }

        public LogCambiosUbicacion Agregar(LogCambiosUbicacion entidad)
        {
            entidad.logId = Guid.NewGuid();
            this._db.LogCambiosUbicacion.Add(entidad);
            return entidad;
        }

        public void Editar(LogCambiosUbicacion entidad)
        {
            //var logSeleccionado = this._db.LogCambiosUbicacion.Where(c => c.logId == entidad.logId).FirstOrDefault();
            //if (logSeleccionado != null)
            //{
            //    logSeleccionado.nombre = entidad.nombre;
            //    logSeleccionado.correo = entidad.correo;
            //    logSeleccionado.telefono = entidad.telefono;

            //    this._db.Entry(logSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//enmarca el estado de la entidad en modificado
            //}

            throw new Exception("No se pueden editar los 'LogCambiosUbicacion'");
        }

        public void Eliminar(Guid entidadID)
        {
            //var logSeleccionado = this._db.LogCambiosUbicacion.Where(c => c.logId == entidadID).FirstOrDefault();
            //if (logSeleccionado != null)
            //{

            //    this._db.Remove(logSeleccionado);
            //}

            throw new Exception("No se pueden eliminar los 'LogCambiosUbicacion'");
        }

        public void GuardarTodosLosCambios()
        {
            this._db.SaveChanges();
        }

        public List<LogCambiosUbicacion> Listar()
        {
            return this._db.LogCambiosUbicacion.ToList();
        }

        public LogCambiosUbicacion SeleccionarPorID(Guid entidadID)
        {
            var logSeleccionado = this._db.LogCambiosUbicacion.Where(c => c.logId == entidadID).FirstOrDefault();
            return logSeleccionado;
        }
    }
}
