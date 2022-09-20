using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorID(TEntidadID entidadID);
    }
}
