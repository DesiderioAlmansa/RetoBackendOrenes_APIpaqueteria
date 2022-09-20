using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio.Interfaces;

namespace RetoBackendOrenes.Aplicacion.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
    }
}
