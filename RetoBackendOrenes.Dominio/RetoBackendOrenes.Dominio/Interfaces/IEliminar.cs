using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        void Eliminar(TEntidadID entidadID);
    }
}
