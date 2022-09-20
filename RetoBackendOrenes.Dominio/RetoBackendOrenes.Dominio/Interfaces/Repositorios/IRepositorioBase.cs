using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio.Interfaces;

namespace RetoBackendOrenes.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID>, ITransaccion
    {
    }
}
